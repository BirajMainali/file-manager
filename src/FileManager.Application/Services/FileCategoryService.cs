using System.Transactions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services;

public class FileCategoryService : IFileCategoryService
{
    private readonly IFileCategoryRepository _fileCategoryRepository;
    private readonly IFileRecordInfoRepository _fileRecordInfoRepository;

    public FileCategoryService(IFileCategoryRepository fileCategoryRepository, IFileRecordInfoRepository fileRecordInfoRepository)
    {
        _fileRecordInfoRepository = fileRecordInfoRepository;
        _fileCategoryRepository = fileCategoryRepository;

    }
    public async Task Create(FileCategoryDto dto)
    {

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var category = new FileCategory(dto.Name, dto.Description, dto.Organization, dto.Priority);
        await _fileCategoryRepository.CreateAsync(category);
        await _fileCategoryRepository.FlushAsync();
        scope.Complete();
    }


    public async Task Update(FileCategory fileCategory, FileCategoryDto dto)
    {
        var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        fileCategory.Update(dto.Name, dto.Description, dto.Organization, dto.Priority);
        _fileCategoryRepository.Update(fileCategory);
        await _fileCategoryRepository.FlushAsync();
        scope.Complete();
    }

    public async Task Remove(FileCategory fileCategory)
    {
        var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        if (await _fileRecordInfoRepository.CheckIfExistAsync(x => x.FileCategoryId == fileCategory.Id))
        {
            throw new Exception("Can not Remove, Record exist.");
        }
        _fileCategoryRepository.Remove(fileCategory);
        await _fileCategoryRepository.FlushAsync();
        scope.Complete();
    }
}