using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using MessagePack;

namespace ConsoleApp
{
    public static class MyStringService
    {
        public const string JsonPath = "MyString.json";
        public const string XmlPath = "MyString.xml";
        public const string BinPath = "MyString.bin"; // MessagePack
        public const string UserPath = "MyString.txt";

        // ---------------- JSON ----------------
        public static void SerializeJson<T>(T data)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, opts);
            File.WriteAllText(JsonPath, json, Encoding.UTF8);
        }

        public static T? DeserializeJson<T>()
        {
            if (!File.Exists(JsonPath)) return default;
            var json = File.ReadAllText(JsonPath, Encoding.UTF8);
            return JsonSerializer.Deserialize<T>(json);
        }

        // ---------------- XML ----------------
        public static void SerializeXml<T>(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var writer = XmlWriter.Create(XmlPath, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 });
            serializer.Serialize(writer, data);
        }

        public static T? DeserializeXml<T>()
        {
            if (!File.Exists(XmlPath)) return default;
            var serializer = new XmlSerializer(typeof(T));
            using var reader = XmlReader.Create(XmlPath);
            var obj = serializer.Deserialize(reader);
            return (T?)obj;
        }

        // ---------------- Binary (MessagePack) ----------------
        public static void SerializeBinary<T>(T data)
        {
            var bytes = MessagePackSerializer.Serialize(data);
            File.WriteAllBytes(BinPath, bytes);
        }

        public static T? DeserializeBinary<T>()
        {
            if (!File.Exists(BinPath)) return default;
            var bytes = File.ReadAllBytes(BinPath);
            return MessagePackSerializer.Deserialize<T>(bytes);
        }

        // ---------------- Сustom User----------------
        public static void SerializeUser(IEnumerable<MyString> data)
        {
            var lines = data.Select(x => x.ToUserLine()).ToArray();
            File.WriteAllLines(UserPath, lines, Encoding.UTF8);
        }

        public static List<MyString>? DeserializeUser()
        {
            if (!File.Exists(UserPath)) return null;
            var lines = File.ReadAllLines(UserPath, Encoding.UTF8);
            var list = new List<MyString>();
            foreach (var ln in lines)
            {
                var item = MyString.FromUserLine(ln);
                if (item != null) list.Add(item);
            }
            return list;
        }

        // Порівняння масивів за змістовними полями
        public static bool ArraysEqual(MyString[] a, MyString[] b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Value != b[i].Value) return false;
                if (a[i].Key != b[i].Key) return false;
                if (a[i].Direction != b[i].Direction) return false;
                if (a[i].EncryptedValue != b[i].EncryptedValue) return false;
            }
            return true;
        }

        // Повернення розмірів файлів для порівняння
        public static (long json, long xml, long bin, long user) GetFilesSizes()
        {
            long j = File.Exists(JsonPath) ? new FileInfo(JsonPath).Length : -1;
            long x = File.Exists(XmlPath) ? new FileInfo(XmlPath).Length : -1;
            long b = File.Exists(BinPath) ? new FileInfo(BinPath).Length : -1;
            long u = File.Exists(UserPath) ? new FileInfo(UserPath).Length : -1;
            return (j, x, b, u);
        }
    }
}
