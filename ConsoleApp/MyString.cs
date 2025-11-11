using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MessagePack;

namespace ConsoleApp
{
    [MessagePackObject]
    public class MyString
    {
        [MessagePack.Key(0)]
        public string Value { get; set; } = string.Empty;

        [MessagePack.Key(1)]
        public int Length { get; set; }

        // Закритий ключ (на скільки зсуваємо код символа)
        [MessagePack.Key(2)]
        public int Key { get; set; } = 1;

        // Напрямок: true = зсуваємо вперед при шифруванні (Encrypt додає Key)
        [MessagePack.Key(3)]
        public bool Direction { get; set; } = true;

        // Зашифрованное поле для збереження результату шифрування
        [MessagePack.Key(4)]
        public string EncryptedValue { get; set; } = string.Empty;

        public MyString() { } // для серіалізаторів

        public MyString(string value, int key = 1, bool direction = true)
        {
            Value = value ?? string.Empty;
            Length = Value.Length;
            Key = key;
            Direction = direction;
            EncryptedValue = string.Empty;
        }

        // Шифрування Value => EncryptedValue
        public void Encrypt()
        {
            var sb = new StringBuilder(Length);
            foreach (var ch in Value)
            {
                int shifted = ch + (Direction ? Key : -Key);
                if (shifted < char.MinValue) shifted = char.MinValue;
                if (shifted > char.MaxValue) shifted = char.MaxValue;
                sb.Append((char)shifted);
            }
            EncryptedValue = sb.ToString();
        }

        // Дешифрування EncryptedValue (повертає відновлену строку)
        public string Decrypt()
        {
            if (string.IsNullOrEmpty(EncryptedValue)) return string.Empty;
            var sb = new StringBuilder(EncryptedValue.Length);
            foreach (var ch in EncryptedValue)
            {
                int shifted = ch + (Direction ? -Key : Key);
                if (shifted < char.MinValue) shifted = char.MinValue;
                if (shifted > char.MaxValue) shifted = char.MaxValue;
                sb.Append((char)shifted);
            }
            return sb.ToString();
        }

        // Подібно до MyLine.CountChar
        public int CountChar(char c) => Value.Count(x => x == c);

        public void Reverse()
        {
            Value = new string(Value.Reverse().ToArray());
            Length = Value.Length;
        }

        public void AddString(string extra)
        {
            Value += extra ?? string.Empty;
            Length = Value.Length;
        }

        public override string ToString() => Value;

        // Користувацький текстовий рядок (user format)
        public string ToUserLine()
        {
            return "{" +
                   $"Value:{Escape(Value)}," +
                   $"Length:{Length}," +
                   $"Key:{Key}," +
                   $"Dir:{(Direction ? 1 : 0)}," +
                   $"Enc:{Escape(EncryptedValue)}" +
                   "}";
        }

        public static MyString? FromUserLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            var start = line.IndexOf('{');
            var end = line.LastIndexOf('}');
            if (start < 0 || end < 0 || end <= start) return null;
            var inner = line.Substring(start + 1, end - start - 1);
            var parts = SplitRespectingEscapes(inner);

            string val = "";
            string enc = "";
            int key = 0;
            bool dir = true;
            int length = 0;

            foreach (var p in parts)
            {
                var idx = p.IndexOf(':');
                if (idx < 0) continue;
                var k = p.Substring(0, idx).Trim();
                var v = p.Substring(idx + 1).Trim();
                switch (k)
                {
                    case "Value": val = Unescape(v); break;
                    case "Length": int.TryParse(v, out length); break;
                    case "Key": int.TryParse(v, out key); break;
                    case "Dir": dir = v == "1"; break;
                    case "Enc": enc = Unescape(v); break;
                }
            }

            var ms = new MyString(val, key, dir) { Length = length, EncryptedValue = enc };
            return ms;
        }

        private static string Escape(string s) => (s ?? "").Replace("\\", "\\\\").Replace(",", "\\,").Replace(":", "\\:").Replace("{", "\\{").Replace("}", "\\}");
        private static string Unescape(string s)
        {
            if (s == null) return "";
            return s.Replace("\\:", ":").Replace("\\,", ",").Replace("\\{", "{").Replace("\\}", "}").Replace("\\\\", "\\");
        }

        // Розділення комами
        private static string[] SplitRespectingEscapes(string s)
        {
            var list = new System.Collections.Generic.List<string>();
            var sb = new StringBuilder();
            bool esc = false;
            foreach (var ch in s)
            {
                if (esc)
                {
                    sb.Append(ch);
                    esc = false;
                }
                else
                {
                    if (ch == '\\') esc = true;
                    else if (ch == ',')
                    {
                        list.Add(sb.ToString());
                        sb.Clear();
                    }
                    else sb.Append(ch);
                }
            }
            list.Add(sb.ToString());
            return list.ToArray();
        }
    }
}
