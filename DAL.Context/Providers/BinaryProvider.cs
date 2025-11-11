using System;
using System.Collections.Generic;
using System.IO;
using MessagePack;

namespace DAL.Providers
{
    public class BinaryProvider<T> : IDataProvider<T>
    {
        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            var bytes = File.ReadAllBytes(filePath);
            var data = MessagePackSerializer.Deserialize<List<T>>(bytes);

            if (data == null)
                return new List<T>();
            else
                return data;
        }

        public void Save(IEnumerable<T> items, string filePath)
        {
            var bytes = MessagePackSerializer.Serialize(items);
            File.WriteAllBytes(filePath, bytes);
        }
    }
}
