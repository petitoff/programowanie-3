using System.IO;
using System.Xml.Serialization;

namespace lista_3.Service
{
    public static class CustomersSerialize
    {
        public static void SerializeToXml<T>(T modelObject, string xmlFilePath)
        {
            var xmlSerializer = new XmlSerializer(modelObject?.GetType()!);

            using var writer = File.CreateText(xmlFilePath);
            if (modelObject != null)
            {
                xmlSerializer.Serialize(writer, modelObject);
            }
        }
    }
}
