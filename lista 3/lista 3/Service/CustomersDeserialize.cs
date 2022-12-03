using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lista_3.Service
{
    public static class CustomersDeserialize
    {
        public static T DeserializeFromXml<T>(string filepath) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using var sr = new StreamReader(filepath);
            return (T)xmlSerializer.Deserialize(sr);
        }
    }
}
