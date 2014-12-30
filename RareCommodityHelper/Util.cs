using System;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;

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

    private static string ExecutableDir()
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    private static void SaveData(T data, string path, string fileName)
    {
        string fullName = Path.Combine(path, fileName);
        if (File.Exists(fullName))
        {
            File.Delete(fullName);
        }
        FileStream stream = File.OpenWrite(fullName);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stream, data);
        stream.Close();
    }

    private static bool LoadData(string path, string fileName, out T ret)
    {
        string fullName = Path.Combine(path, fileName);
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

    public static void SaveLocalData(T data, string fileName)
    {
        SaveData(data, LocalDataDir(), fileName);
    }

    public static bool LoadLocalData(string fileName, out T ret)
    {
        return LoadData(LocalDataDir(), fileName, out ret);
    }

    public static void SaveRunData(T data, string fileName)
    {
        SaveData(data, ExecutableDir(), fileName);
    }

    public static bool LoadRunData(string fileName, out T ret)
    {
        return LoadData(ExecutableDir(), fileName, out ret);
    }
}

class StringSorter : IComparer
{
    public int Column;
    public bool Ascending = true;

    public StringSorter(int c, bool a)
    {
        Column = c;
        Ascending = a;
    }

    public int Compare(object x, object y)
    {
        string a = ((ListViewItem)x).SubItems[Column].Text;
        string b = ((ListViewItem)y).SubItems[Column].Text;
        return Ascending ? string.Compare(a, b) : string.Compare(b, a);
    }
}

class FloatSorter : IComparer
{
    public int Column;
    public bool Ascending = true;

    public FloatSorter(int c, bool a)
    {
        Column = c;
        Ascending = a;
    }

    public int Compare(object x, object y)
    {
        double a = Convert.ToDouble(((ListViewItem)x).SubItems[Column].Text);
        double b = Convert.ToDouble(((ListViewItem)y).SubItems[Column].Text);
        if (a == b) { return 0; }
        if (!Ascending)
        {
            double t = a;
            a = b;
            b = t;
        }
        return (a > b) ? 1 : -1;
    }
}