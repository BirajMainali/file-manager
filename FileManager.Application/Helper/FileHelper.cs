using FileManager.Application.Helper.Interfaces;
using FileManager.Domain.ValueObject;
using FileManager.Web.Extension;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Helper
{
    public class FileHelper : IFileHelper
    {
        private const string Root = "Content/Files/";

        public async Task<FileRecordVo> SaveImage(IFormFile file)
        {
            if (file.IsFile()) throw new Exception("Invalid file type.");
            EnsureDirectoryIsCreated(Root);
            var extension = Path.GetExtension(file.FileName);
            var encryptedFileName = new Guid() + extension;
            var filePath = Path.Combine(Root, encryptedFileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return new FileRecordVo()
            {
                Identity = encryptedFileName,
                Path = filePath,
                Size = file.Length / 1024,
                ContentType = file.ContentType,
            };
        }

        public void RemoveImage(string identity) => File.Delete(Root + identity);

        public void EnsureDirectoryIsCreated(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }
        }
    }
}