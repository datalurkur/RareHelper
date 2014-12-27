using System.IO;
using System.Xml.Serialization;

class LocalData<T>
{
    private static string LocalDataDir()
    {
        string ret = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "RareHelper");
        if (!Directory.Exists(ret))
        {
            Directory.CreateDirectory(ret);
        }
        return ret;
    }

    public static void SaveLocalData(T data, string fileName)
    {
        string fullName = Path.Combine(LocalDataDir(), fileName);
        if (File.Exists(fullName))
        {
            File.Delete(fullName);
        }
        FileStream stream = File.OpenWrite(fullName);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stream, data);
        stream.Close();
    }

    public static bool LoadLocalData(string fileName, out T ret)
    {
        string fullName = Path.Combine(LocalDataDir(), fileName);
        if (File.Exists(fullName))
        {
            FileStream stream = File.OpenRead(fullName);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            ret = (T)serializer.Deserialize(stream);
            stream.Close();
            return true;
        }
        ret = default(T);
        return false;
    }
}