using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class ZipTask
    {
        public string ArcName;
        public string ArcPath;
        public string FileName;
        public string FilePath;

        public ZipTask(string arc, string file)
        {
            FileName = file;
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            ArcName = arc;
            ArcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ArcName);
            CreateArchive();
            InsertFile();
            ReadFileFromArchive();
            DeleteArchive();
        }

        public void CreateArchive()
        {
            if (!File.Exists(FilePath))
            {
                using (ZipArchive zipArchive = ZipFile.Open(FilePath, ZipArchiveMode.Create))
                {
                    zipArchive.Dispose();
                }
            }
        }

        public void InsertFile()
        {
            using (ZipArchive archive = ZipFile.Open(ArcPath, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(FilePath, FileName);
            }
        }

        public void ReadFileFromArchive()
        {
            string destinationFolderPath = "unzip";
            using (ZipArchive archive = ZipFile.Open(ArcPath, ZipArchiveMode.Read))
            {
                ZipArchiveEntry entry = archive.GetEntry(FileName);
                entry.ExtractToFile(Path.Combine(destinationFolderPath, entry.Name));
            }
            string fileContents = File.ReadAllText(Path.Combine(destinationFolderPath, FileName));
            Console.WriteLine(fileContents);
        }

        public void DeleteArchive()
        {
            if (File.Exists(ArcPath))
            {
                File.Delete(ArcPath);
                Console.WriteLine("Архив {0} удалён", ArcName);
            }
            else
            {
                Console.WriteLine("Архива {0} не существует", ArcName);
            }

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
