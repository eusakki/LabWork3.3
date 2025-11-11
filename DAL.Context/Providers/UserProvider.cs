using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAL.Providers
{
    public class UserProvider<T> : IDataProvider<T> where T : class, new()
    {
        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            if (lines.Length == 0) return new List<T>();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var header = lines[0].Split(';');
            var list = new List<T>();

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(';');
                var obj = new T();

                for (int j = 0; j < header.Length && j < parts.Length; j++)
                {
                    var p = props.FirstOrDefault(x => x.Name.Equals(header[j], StringComparison.OrdinalIgnoreCase));
                    if (p == null) continue;

                    try
                    {
                        var converted = Convert.ChangeType(parts[j], p.PropertyType);
                        p.SetValue(obj, converted);
                    }
                    catch
                    {
                        // Ignore conversion errors
                    }
                }
                list.Add(obj);
            }

            if (list == null)
                return new List<T>();
            else
                return list;
        }

        public void Save(IEnumerable<T> items, string filePath)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var header = string.Join(";", props.Select(p => p.Name));
            var sb = new StringBuilder();
            sb.AppendLine(header);

            foreach (var item in items)
            {
                var vals = new List<string>();

                foreach (var p in props)
                {
                    var v = p.GetValue(item);
                    string s;

                    if (v == null)
                        s = "";
                    else 
                        s = v.ToString();

                    s = s.Replace(";", "\\;");
                    vals.Add(s);
                }

                sb.AppendLine(string.Join(";", vals));
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}
