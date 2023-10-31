using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            string fileData;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    DiskInfo info = new DiskInfo();
                    info.getDriveInfo();
                    break;
                case 1:
                    Console.WriteLine("Введите название файла");
                    fileName = Console.ReadLine() + ".txt";
                    Console.WriteLine("Введите данные файла");
                    fileData = Console.ReadLine();
                    FileTask file = new FileTask(fileName, fileData);
                    break;
                case 2:
                    Console.WriteLine("Введите название файла");
                    fileName = Console.ReadLine() + ".json";
                    JsonTask json_file = new JsonTask(fileName);
                    break;
                case 3:
                    Console.WriteLine("Введите название файла");
                    fileName = Console.ReadLine() + ".txt";
                    Console.WriteLine("Введите данные файла");
                    fileData = Console.ReadLine();
                    XmlTask xml_file = new XmlTask(fileName, fileData);
                    break;
                case 4:
                    Console.WriteLine("Введите название архива");
                    fileName = Console.ReadLine() + ".zip";
                    Console.WriteLine("Введите название файла");
                    string arc_name = Console.ReadLine();
                    ZipTask zip_file = new ZipTask(fileName, arc_name);
                    break;
                default:
                    Console.WriteLine("Закрытие программы");
                    break;
            }
            Console.ReadLine();
        }
    }
}
