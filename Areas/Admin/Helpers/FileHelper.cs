using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.Helpers
{
    public static class FileHelper
    {
        public static string UniqueFileName = "";
        public static bool CheckContent(string contenttype, string format)
        {
            if (contenttype.Contains(format))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckLength(long length, int kb)
        {
            if (length / 1024 < 1500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async static void CreateFile(string filename, string env, string folder, IFormFile file)
        {
            string _filename = Guid.NewGuid().ToString() + filename;
            UniqueFileName = _filename;
            string _resultPath = Path.Combine(env, folder, _filename);
            using (FileStream filestream = new FileStream(_resultPath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
        }

        public static bool FileExists(string filename, string env, string folder)
        {
            string _resultPath = Path.Combine(env, folder, filename);
            return File.Exists(_resultPath);
        }

        public static void DeleteFile(string filename, string env, string folder)
        {
            string _resultPath = Path.Combine(env, folder, filename);
            File.Delete(_resultPath);
        }
    }
}
