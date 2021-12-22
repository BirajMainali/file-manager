using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace FileManager.Web.Extension
{
    public static class FileValidatorExtension
    {
        private static readonly string[] AcceptedFileExtensions = { ".jpg", ".png", ".gif", ".jpeg", ".png", ".xlsx", ".xlsm", ".txt", ".doc", ".docx" };

        public static bool IsFile(this IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!AcceptedFileExtensions.Contains(extension)) return true;
            return false;
        }
    }
}