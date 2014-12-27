using System.Net.Http;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

public class StarCoordinator
{
    private class JSONFilter
    {
        public int cr = 5;
        public int knownstatus = 1;
        public string date = "2014-12-15";
    }

    private class JSONPostData
    {
        public JSONFilter filter = new JSONFilter();
        public int outputmode = 2;
        public bool test = false;
        public int ver = 2;
    }

    private class JSONPost
    {
        public JSONPostData data = new JSONPostData();
    }

    private class JSONSystem
    {
        public int id = 0;
        public string name = "";
        public int cr = 0;
        public string commandercreate = "";
        public string createdate = "";
        public string commanderupdate = "";
        public string updatedate = "";
        public float[] coord = new float[0];
    }

    private class JSONInputStatus
    {
        public int statusnum = 0;
        public string msg = "";
    }

    private class JSONInput
    {
        public JSONInputStatus status = new JSONInputStatus();
    }

    private class JSONStatus
    {
        public JSONInput[] input = new JSONInput[0];
    }

    private class JSONResponseData
    {
        public string ver = "";
        public string date = "";
        public JSONStatus status = new JSONStatus();
        public JSONSystem[] systems = new JSONSystem[0];
    }

    private class JSONResponse
    {
        public JSONResponseData d = new JSONResponseData();
    }

    public class CachedData
    {
        public List<StarSystem> systemData;
        public string dateSynced;

        public CachedData()
        {
            dateSynced = "";
            systemData = null;
        }

        public CachedData(Dictionary<string, StarSystem> data)
        {
            systemData = new List<StarSystem>();
            foreach (StarSystem value in data.Values)
            {
                systemData.Add(value);
            }
        }

        public Dictionary<string, StarSystem> GetDictionary()
        {
            Dictionary<string, StarSystem> ret = new Dictionary<string, StarSystem>();
            foreach (StarSystem system in systemData)
            {
                ret[system.Name] = system;
            }
            return ret;
        }
    }

    public static async Task<Dictionary<string,StarSystem>> FetchSystems()
    {
        // Get existing data from the cache
        CachedData preexistingData;
        Dictionary<string, StarSystem> ret = new Dictionary<string, StarSystem>();
        string lastSynced = "2014-01-01";
        if (LocalData<CachedData>.LoadLocalData("EDSystemCache.xml", out preexistingData))
        {
            lastSynced = preexistingData.dateSynced;
            ret = preexistingData.GetDictionary();
        }
        else
        {
            MessageBox.Show("It looks like this is your first time using the tool.  This next part might take a second.  Just be patient.", "Fuck!", MessageBoxButtons.OK);
        }

        // Get fresh data from the web
        JSONSystem[] newData = await FetchSystemsFromWeb(lastSynced);
        foreach (JSONSystem s in newData)
        {
            StarSystem n = new StarSystem();
            n.Name = s.name;
            n.Position = new Coords();
            n.Position.X = s.coord[0];
            n.Position.Y = s.coord[1];
            n.Position.Z = s.coord[2];
            ret[n.Name] = n;
        }

        // Save the new cache
        CachedData newCache = new CachedData(ret);
        newCache.dateSynced = string.Format("{0}-{1}-{2}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
        LocalData<CachedData>.SaveLocalData(newCache, "EDSystemCache.xml");

        return ret;
    }

    private static async Task<JSONSystem[]> FetchSystemsFromWeb(string lastSynced)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        JSONPost postData = new JSONPost();
        postData.data.filter.date = lastSynced;

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = 1024 * 1024 * 100; // Allow some ridiculously long string
        string content = serializer.Serialize(postData);

        HttpResponseMessage response = await client.PostAsync(
            "http://edstarcoordinator.com/api.asmx/GetSystems",
            new StringContent(content, System.Text.Encoding.UTF8, "application/json")
        );

        string responseString = await response.Content.ReadAsStringAsync();
        JSONResponse parsed = serializer.Deserialize<JSONResponse>(responseString);
        return parsed.d.systems;
    }
}