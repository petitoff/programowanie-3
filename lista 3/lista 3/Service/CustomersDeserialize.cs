using System;
using System.IO;
using System.Xml.Serialization;

namespace lista_3.Service
{
    public static class CustomersDeserialize
    {
        public static T? DeserializeFromXml<T>(string filePath) where T : class
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                using var sr = new StreamReader(filePath);
                return (T)xmlSerializer.Deserialize(sr);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }
    }
}
