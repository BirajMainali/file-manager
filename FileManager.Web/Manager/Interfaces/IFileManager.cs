using System.Threading.Tasks;
using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManager.Web.Manager.Interfaces
{
    public interface IFileManager
    {
        Task SaveFileInfo(IFormFile file, string fileName);
        Task RemoveFileInfo(FileRecordInfo @record);
    }
}