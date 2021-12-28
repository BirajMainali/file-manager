using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services.Interface
{
    public interface IFileCategoryService
    {
        Task Create(FileCategoryDto dto);
        Task Update(FileCategory fileCategory,FileCategoryDto dto);
        Task Remove(FileCategory fileCategory);
    }
}