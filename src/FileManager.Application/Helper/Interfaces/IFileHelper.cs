using FileManager.Domain.ValueObject;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Helper.Interfaces;

public interface IFileHelper
{
    Task<FileRecordVo> SaveImage(IFormFile file, long organizationId, string? type = null);
    void RemoveImage(long organizationId, string identity);
}