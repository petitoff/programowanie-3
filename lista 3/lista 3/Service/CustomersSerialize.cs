using System.IO;
using System.Xml.Serialization;

namespace lista_3.Service
{
    public class CustomersSerialize
    {
        public static void SerializeToXml<T>(T modelObject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(modelObject.GetType());

            using (StreamWriter writer = File.CreateText(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, modelObject);
            }
        }
    }
}
