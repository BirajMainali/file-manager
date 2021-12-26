using FileManager.Application.Repository.Base;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<bool> IsEmailUsed(string email, long? excludedId = null)
    {
        return await CheckIfExistAsync(x =>
            (excludedId == null || x.Id != excludedId) && x.Email.Trim().ToLower() == email.Trim().ToLower());
    }
}