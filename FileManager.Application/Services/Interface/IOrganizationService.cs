using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services.Interface;

public interface IOrganizationService
{
    Task<Organization> Create(OrganizationDto dto);
    Task Update(Organization organization, OrganizationDto dto);
    Task Remove(Organization organization);
}