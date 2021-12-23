using FileManager.Application.Repository.Base;
using FileManager.Application.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository{

public class UserRepository : BaseRepository<Domain.Entities.User.User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
        
    }
    public async Task<bool> IsEmailUsed(string email, long? excludedId = null) 
        => await CheckIfExistAsync(x => (excludedId == null || x.Id != excludedId) && x.Email.Trim().ToLower() == email.Trim().ToLower());

}
}