using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp;
using MessagePack;

namespace Labwork3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var arr = new MyString[]
            {
                new MyString("Hello", 2, true),
                new MyString("World", 3, true),
                new MyString("Kyiv", 1, false),
                new MyString("Encryption", 5, true),
                new MyString("Test123", 4, true),
                new MyString("Привіт", 2, true)
            };

            // Шифруємо кожен об'єкт
            foreach (var s in arr) s.Encrypt();

            // Серіалізація масива в 4 формата
            MyStringService.SerializeJson(arr);
            MyStringService.SerializeXml(arr);
            MyStringService.SerializeBinary(arr); // MessagePack
            MyStringService.SerializeUser(arr);

            Console.WriteLine("Saved array to files (JSON, XML, Binary(MessagePack), Custom text).");

            // Десеріалізація в нові масиви
            var fromJson = MyStringService.DeserializeJson<MyString[]>();
            var fromXml = MyStringService.DeserializeXml<MyString[]>();
            var fromBin = MyStringService.DeserializeBinary<MyString[]>();
            var fromUser = MyStringService.DeserializeUser()?.ToArray();

            // Виведення вмісту десеріалізованих масивів
            PrintSection("From JSON", fromJson);
            PrintSection("From XML", fromXml);
            PrintSection("From MessagePack(Binary)", fromBin);
            PrintSection("From Custom User", fromUser);

            // Колекції List<T> — серіалізація та порівняння
            var list = new List<MyString>(arr);
            // Зміна першого елементу для демонстрації різниці
            list[0].Value = "Hello_Modified";
            list[0].Length = list[0].Value.Length;
            list[0].Encrypt();

            // Для демонстрації - збереження колекції в JSON
            MyStringService.SerializeJson(list);
            var loadedList = MyStringService.DeserializeJson<List<MyString>>();

            Console.WriteLine($"\nOriginal array[0].Value = {arr[0].Value}");
            Console.WriteLine($"Loaded list[0].Value    = {loadedList?[0].Value}");

            // Порівняння
            bool eqJson = MyStringService.ArraysEqual(arr, fromJson ?? Array.Empty<MyString>());
            bool eqUser = fromUser != null && MyStringService.ArraysEqual(arr, fromUser);

            Console.WriteLine($"\nЧи рівні оригінальний масив і десеріалізований масив JSON? {eqJson}");
            Console.WriteLine($"Чи рівні оригінальний масив і масив, десеріалізований користувачем? {eqUser}");
        }

        static void PrintSection(string title, MyString[]? arr)
        {
            Console.WriteLine($"\n--- {title} ---");
            if (arr == null)
            {
                Console.WriteLine("<null>");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                var it = arr[i];
                Console.WriteLine($"[{i}] Value=\"{it.Value}\", Key={it.Key}, Dir={(it.Direction ? "forward" : "backward")}, Encrypted=\"{it.EncryptedValue}\"");
            }
        }
    }
}
