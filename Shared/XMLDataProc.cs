using System.IO;
using System.Xml.Serialization;

namespace DND.Shared
{
    public static class XMLDataProc
    {
        public static void WriteList(string path, object data)
        {
            var writer = new XmlSerializer(data.GetType());
            var wfile = new StreamWriter(path + ".xml");
            writer.Serialize(wfile, data);
            wfile.Close();
        }
        public static object ReadList(string path, object data)
        {
            var reader = new XmlSerializer(data.GetType());
            var file = new StreamReader(path + ".xml");
            var output = reader.Deserialize(file);
            file.Close();
            return output;
        }
    }
}
