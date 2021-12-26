using FileManager.Application.Repository.Base;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository;

public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(DbContext context) : base(context)
    {
    }

    public async Task<bool> IsOrganizationUsed(string email, long? excludedId = null)
    {
        return await CheckIfExistAsync(x =>
            (excludedId == null || x.Id != excludedId) && x.Email.Trim().ToLower() == email.Trim().ToLower());
    }
}