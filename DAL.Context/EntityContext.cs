using System;
using System.Collections.Generic;
using DAL.Providers;

namespace DAL
{
    public class EntityContext
    {
        public EntityContext() { }

        public List<T> LoadAll<T>(string type, string path) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("File type must be specified.", nameof(type));

            type = type.ToLower();

            IDataProvider<T> provider = type switch
            {
                "json" => new JsonProvider<T>(),
                "xml" => new XmlProvider<T>(),
                "binary" => new BinaryProvider<T>(),
                "user" => new UserProvider<T>(),
                _ => throw new NotSupportedException($"Unsupported file type: {type}")
            };

            var result = provider.Load(path);
            return new List<T>(result);
        }

        public void SaveAll<T>(IEnumerable<T> items, string type, string path) where T : class, new()
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("File type must be specified.", nameof(type));

            type = type.ToLower();

            IDataProvider<T> provider = type switch
            {
                "json" => new JsonProvider<T>(),
                "xml" => new XmlProvider<T>(),
                "binary" => new BinaryProvider<T>(),
                "user" => new UserProvider<T>(),
                _ => throw new NotSupportedException($"Unsupported file type: {type}")
            };

            provider.Save(items, path);
        }
    }
}
