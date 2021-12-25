using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services.Interface;

public interface IPermissionService
{
    Task Create(PermissionDto dto);
    Task Update(Permission permission, PermissionDto dto);
}