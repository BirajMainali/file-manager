using FileManager.Application.Extensions;
using FileManager.Application.Helper.Interfaces;
using FileManager.Domain.ValueObject;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Helper;

public class FileHelper : IFileHelper
{
    private static string _root = "Content/Files/";

    public FileHelper()
    {
    }

    public async Task<FileRecordVo> SaveImage(IFormFile file, long organizationId, string? type = null)
    {
        if (file.IsFile()) throw new Exception("Invalid file type.");
        _root = _root + "/" + organizationId;
        if (!string.IsNullOrEmpty(type)) _root = $"{_root}/{type}/";
        EnsureDirectoryIsCreated(_root);
        var extension = Path.GetExtension(file.FileName);
        var encryptedFileName = new Guid() + extension;
        var filePath = Path.Combine(_root, encryptedFileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        return new FileRecordVo
        {
            Identity = encryptedFileName,
            Path = _root,
            Size = file.Length / 1024,
            ContentType = file.ContentType,
            Extension = extension
        };
    }

    public void RemoveImage(long organizationId, string identity)
    {
        _root = _root + "/" + identity;
        File.Delete(_root + identity);
    }

    public void EnsureDirectoryIsCreated(string rootDirectory)
    {
        if (!Directory.Exists(rootDirectory)) Directory.CreateDirectory(rootDirectory);
    }
}