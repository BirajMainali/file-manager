using System.Transactions;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Dto;
using FileManager.Domain.Entities;
using FileManager.Domain.ValueObject;

namespace FileManager.Application.Manager;

public class OrganizationUserManager : IOrganizationUserManager
{
    private readonly IUserService _userService;
    private readonly IOrganizationService _organizationService;

    public OrganizationUserManager(IUserService userService, IOrganizationService organizationService)
    {
        _userService = userService;
        _organizationService = organizationService;
    }

    public async Task CreateOrganization(OrganizationUserVo vo)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var organization = await _organizationService.Create(ReadyOrganizationDto(vo));
        await _userService.CreateUser(ReadyUserDto(vo, organization));
        tsc.Complete();
    }

    public async Task RemoveOrganization(Organization organization, Domain.Entities.User.User user)
    {
        using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await _organizationService.Remove(organization);
        await _userService.Remove(user);
        tsc.Complete();
    }

    private UserDto ReadyUserDto(OrganizationUserVo vo, Organization organization)
        => new UserDto()
        {
            Organization = organization,
            Name = vo.Name,
            Address = vo.Address,
            Email = vo.Email,
            Gender = vo.Gender,
            Password = vo.Password,
            Phone = vo.Phone
        };

    private OrganizationDto ReadyOrganizationDto(OrganizationUserVo vo)
        => new OrganizationDto()
        {
            OrgName = vo.OrgName,
            Address = vo.Address,
            Fax = vo.Fax,
            Phone = vo.Phone,
            Description = vo.Description,
            Email = vo.Email
        };
}