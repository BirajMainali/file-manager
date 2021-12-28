using System.Collections.Generic;
using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FileManager.Web.ViewModels;

public class FileUploadVm
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public List<FileCategory> FileCategories { get; set; }
    public long FileCategoryId { get; set; }
    public string? Description { get; set; }

    public SelectList FileCategoriesOptions()
        => new SelectList(FileCategories, nameof(FileCategory.Name), nameof(FileCategory.Id), FileCategoryId);
}