using FileManager.Domain.Entities;
using FileManager.Domain.ValueObject;

namespace FileManager.Application.Manager.Interfaces;

public interface IOrganizationUserManager
{
    Task CreateOrganization(OrganizationUserVo vo);
    Task RemoveOrganization(Organization organization, User user);
}