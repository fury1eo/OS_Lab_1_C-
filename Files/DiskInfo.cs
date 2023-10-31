using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class DiskInfo
    {
        public void getDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                Console.WriteLine("Диск {0}", drive.Name);
                Console.WriteLine("\tМетка тома - {0}", drive.VolumeLabel);
                Console.WriteLine("\tТип файловой системы - {0}", drive.DriveFormat);
                Console.WriteLine("\tИспользовано места - {0} Gb", ((drive.TotalSize - drive.AvailableFreeSpace) / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine("\tСвободно - {0} Gb", (drive.AvailableFreeSpace / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine("\tВсего - {0} Gb", (drive.TotalSize / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine();
            }

        }
    }
}
