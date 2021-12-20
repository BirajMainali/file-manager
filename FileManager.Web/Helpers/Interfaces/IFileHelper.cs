using System.Threading.Tasks;
using FileManager.ValueObject;
using Microsoft.AspNetCore.Http;

namespace FileManager.Helpers.Interfaces
{
    public interface IFileHelper
    {
        Task<FileRecordVo> SaveImage(IFormFile file, string name);
        void RemoveImage(string identity);
        void EnsureDirectoryIsCreated(string directory);
    }
}