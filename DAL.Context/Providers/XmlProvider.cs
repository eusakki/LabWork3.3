using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Providers
{
    public class XmlProvider<T> : IDataProvider<T>
    {
        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            using var fs = File.OpenRead(filePath);
            var ser = new XmlSerializer(typeof(List<T>));
            var data = (List<T>)ser.Deserialize(fs);
            
            if (data == null)
                return new List<T>();
            else
                return data;
        }

        public void Save(IEnumerable<T> items, string filePath)
        {
            using var fs = File.Create(filePath);
            var ser = new XmlSerializer(typeof(List<T>));
            ser.Serialize(fs, items);
        }
    }
}
