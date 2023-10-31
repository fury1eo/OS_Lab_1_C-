using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class FileTask
    {
        public string FileName;
        public string FileData;
        public string FilePath;
        public FileTask(string name, string data)
        {
            FileName = name;
            FileData = data;
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            CreateFile();
            InsertStringToFile();
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

        public void InsertStringToFile()
        {
            File.WriteAllText(FilePath, FileData);
        }

        public void ReadFile()
        {
            string text = File.ReadAllText(FilePath);
            Console.WriteLine(text);
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
