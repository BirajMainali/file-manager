using FileManager.Domain.ValueObject;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Helper.Interfaces
{
    public interface IFileHelper
    {
        Task<FileRecordVo> SaveImage(IFormFile file);
        void RemoveImage(string identity);
        void EnsureDirectoryIsCreated(string directory);
    }
}