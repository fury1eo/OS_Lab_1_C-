using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Files
{
    class XmlTask
    {
        public string FileName;
        public string FilePath;
        public string FileData;
        public XmlTask(string name, string data)
        {
            FileName = name;
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            FileData = data;
            CreateFile();
            InsertDataToFile();
            ReadFile();
            DeleteFile();
        }

        public void CreateFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.CreateElement("Root");

            doc.AppendChild(declaration);
            doc.AppendChild(root);

            doc.Save(FilePath);
        }

        public void InsertDataToFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            XmlElement root = doc.DocumentElement;

            XmlElement messageElement = doc.CreateElement("Data");
            messageElement.InnerText = FilePath;

            root.AppendChild(messageElement);

            doc.Save(FilePath);
        }

        public void ReadFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            XmlNodeList messageNodes = doc.GetElementsByTagName("Data");

            foreach (XmlNode node in messageNodes)
            {
                Console.WriteLine(node.InnerText);
            }
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
