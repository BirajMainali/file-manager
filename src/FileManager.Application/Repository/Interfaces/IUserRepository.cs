using FileManager.Application.Repository.Base;
using FileManager.Domain.Entities;

namespace FileManager.Application.Repository.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsEmailUsed(string email, long? excludedId = null);
}