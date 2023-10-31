using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Files
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        public Person(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
    }

    class JsonTask
    {
        public string FileName;
        public string FilePath;
        public JsonTask(string name)
        {
            FileName = name;
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            CreateFile();
            InsertDataToFile();
            ReadFile();
            DeleteFile();
        }

        public void CreateFile()
        {
            if (!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Dispose();
            }
        }

        public void InsertDataToFile()
        {
            Console.WriteLine("Имя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Страна: ");
            string country = Console.ReadLine();

            Person person = new Person(name, age, country);
            string json = JsonSerializer.Serialize(person);
            File.WriteAllText(FilePath, json);
        }

        public void ReadFile()
        {
            string json = File.ReadAllText(FilePath);
            Person person = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(person.Name + " " + person.Age + " " + person.Country);
        }

        public void DeleteFile()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Console.WriteLine("Файл {0} удалён", FileName);
            }
            else
            {
                Console.WriteLine("Файла {0} не существует", FileName);
            }
        }
    }
}
