using FileManager.Domain.Entities;

namespace FileManager.Application.Repository.Interfaces
{
    public interface IUserRepository : Base.IBaseRepository<User>
    {
        Task<bool> IsEmailUsed(string email, long? excludedId = null);
    }
}