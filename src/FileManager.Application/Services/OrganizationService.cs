using System.Transactions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Application.Validator.Interfaces;
using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationValidator _validator;

    public OrganizationService(IOrganizationRepository organizationRepository, IOrganizationValidator validator)
    {
        _organizationRepository = organizationRepository;
        _validator = validator;
    }

    public async Task<Organization> Create(OrganizationDto dto)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await _validator.EnsureUniqueOrg(dto.Email);
        var organization = new Organization(dto.OrgName, dto.Address, dto.Phone, dto.Email, dto.Fax, dto.Url,
            dto.Description, null);
        await _organizationRepository.CreateAsync(organization);
        await _organizationRepository.FlushAsync();
        tsc.Complete();
        return organization;
    }

    public async Task Update(Organization organization, OrganizationDto dto)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await _validator.EnsureUniqueOrg(dto.Email, organization.Id);
        organization.Update(dto.OrgName, dto.Address, dto.Phone, dto.Email, dto.Fax, dto.Url, dto.Description, null);
        _organizationRepository.Update(organization);
        await _organizationRepository.FlushAsync();
        tsc.Complete();
    }

    public async Task Remove(Organization organization)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        _organizationRepository.Remove(organization);
        await _organizationRepository.FlushAsync();
        tsc.Complete();
    }
}