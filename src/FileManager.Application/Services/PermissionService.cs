using System.Transactions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task Create(PermissionDto dto)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var permission = new Permission(dto.PermissionTypes, dto.User);
        await _permissionRepository.CreateAsync(permission);
        await _permissionRepository.FlushAsync();
        tsc.Complete();
    }

    public async Task Update(Permission permission, PermissionDto dto)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await RemovePreviousPermission(dto.User.Id);
        await Create(dto);
        tsc.Complete();
    }

    private async Task RemovePreviousPermission(long userId)
    {
        var previousPermission = await _permissionRepository.GetAllAsync(x => x.UserId == userId);
        foreach (var permission in previousPermission) _permissionRepository.Remove(permission);

        await _permissionRepository.FlushAsync();
    }
}