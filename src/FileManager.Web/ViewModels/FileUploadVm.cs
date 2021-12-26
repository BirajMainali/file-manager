using Microsoft.AspNetCore.Http;

namespace FileManager.Web.ViewModels;

public class FileUploadVm
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public string? Description { get; set; }
}