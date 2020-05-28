using NavmiiTest.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavmiiTest.FactoryClass
{
    public class FilesTransfer : IFilesTransfer
    {
        readonly string sourceDir = ConfigurationManager.AppSettings["SourceFolder"];
        readonly string targetDir = ConfigurationManager.AppSettings["TargetFolder"];
        public FilesTransfer()
        {
            if (!(Directory.Exists(sourceDir)))
            {
                Directory.CreateDirectory(sourceDir);
            }
            if (!(Directory.Exists(targetDir)))
            {
                Directory.CreateDirectory(targetDir);
            }
        }
        public int Copy()
        {
            var sourceFileCount = Directory.EnumerateFiles(sourceDir).Count();
            if (sourceFileCount == 0)
            {
                CreateSourceFolderFiles(sourceDir);
            }

            var targetFileCount = Directory.EnumerateFiles(targetDir).Count();
            if (targetFileCount != 0)
            {
                DeleteTargetFolderFiles(targetDir);
            }
   
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            }

            return Directory.EnumerateFiles(targetDir).Count();
        }

        public int Move()
        {
            var sourceFileCount = Directory.EnumerateFiles(sourceDir).Count();
            if (sourceFileCount != 0)
            {
                CreateSourceFolderFiles(sourceDir);
            }

            var targetFileCount = Directory.EnumerateFiles(targetDir).Count();
            if (targetFileCount != 0)
            {
                DeleteTargetFolderFiles(targetDir);
            }

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Move(file, Path.Combine(targetDir, Path.GetFileName(file)));
            }

            return Directory.EnumerateFiles(targetDir).Count();
        }

        public void CreateSourceFolderFiles(string sourceDir)
        {
            var paths = new List<string>(ConfigurationManager.AppSettings["paths"].Split(new char[] { ';' }));
            foreach (var path in paths)
            {
                using (StreamWriter sw = File.CreateText(Path.Combine(sourceDir, path)))
                {
                    sw.WriteLine("New file created: {0}", path.Split('.')[0]);
                }
            }
        }
        public void DeleteTargetFolderFiles(string targetDir)
        {
            DirectoryInfo dir = new DirectoryInfo(targetDir);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
        }
    }
}
