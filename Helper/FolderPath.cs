using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation.Helper
{
    public class FolderPath : BaseClass
    {
        private static string SolutionRoot()
        {
            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            for (var i = 0; i < 3 && dirInfo.Parent != null; ++i)
            {
                dirInfo = dirInfo.Parent;
            }

            return dirInfo.FullName;
        }

        public static string StoreCaptureImage(string fileName)
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", fileName);
        }
        
        public static string SmokeTestOnBuildingSize(string fileName)
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "SmokeTestOnBuildingSize", fileName);
        }
        
        public static string Advanced(string folderName)
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "SmokeTestOnBuildingSize", "RoofStyle", "Advanced", folderName);
        }

        public static bool CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static void WaitForFileDownload(string filePath, int timeoutInSeconds)
        {
            var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);
            while (!FileExists(filePath) && DateTime.Now < endTime)
            {
                CommonMethod.Wait(1);
            }
        }

        public static string ImagesFolder()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "Images");
        }

        public static string CompareJobData()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Excel Sheet And txt file");
        }

        public static string StoreScreenShot()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "Icon Images");
        }

        public static string ScreenShotOfPA_177()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "ScreenShot of PA-177");
        }

        public static string DocumentOfPA_208()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "Document Of PA-208");
        }

        public static string DocumentFile()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "Document Template File(PA-220)");
        }

        public static string Download()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "Downloads");
        }

        public static string PerformanceReport()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Excel Sheet And txt file");
        }

        public static string RoofingPassportFolder()
        {
            var path = SolutionRoot();
            return Path.Combine(path, "Folder", "RoofingPassportScreenShot");
        }
      
    }
}