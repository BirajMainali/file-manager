using FileManager.Application.Repository.Base;
using FileManager.Domain.Entities;

namespace FileManager.Application.Repository.Interfaces;

public interface IOrganizationRepository : IBaseRepository<Organization>
{
    Task<bool> IsOrganizationUsed(string email, long? excludedId = null);
}