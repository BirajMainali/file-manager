using System;
using System.IO;
using System.Threading.Tasks;
using FileManager.Extension;
using FileManager.Helpers.Interfaces;
using FileManager.ValueObject;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Constant = FileManager.Application.Constants.Constant;

namespace FileManager.Web.Helpers
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _env;
        private const string Root = "Content/Files/";

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<FileRecordVo> SaveImage(IFormFile file, string name)
        {
            if (file.IsFile()) throw new Exception("Invalid file type.");
            EnsureDirectoryIsCreated(Root);
            var extension = Path.GetExtension(file.FileName);
            var fileName = name + extension;
            var filePath = Path.Combine(_env.ContentRootPath, Constant.Content, "Files", fileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return new FileRecordVo(fileName, filePath, file.Length / 1024, file.ContentType);
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