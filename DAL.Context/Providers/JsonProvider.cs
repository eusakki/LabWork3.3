using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DAL.Providers
{
    public class JsonProvider<T> : IDataProvider<T>
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            var json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<T>>(json, _options);

            if (data == null)
                return new List<T>();
            else
                return data;
        }

        public void Save(IEnumerable<T> items, string filePath)
        {
            var json = JsonSerializer.Serialize(items, _options);
            File.WriteAllText(filePath, json);
        }
    }
}
