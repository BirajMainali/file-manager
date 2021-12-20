using User.Dto;

namespace FileManager.Application.Services.Interface;

public interface IUserService
{
    Task<FileManager.Domain.Entities.User.User> CreateUser(UserDto dto);
    Task Update(Domain.Entities.User.User user, UserDto dto);
    Task Remove(Domain.Entities.User.User user);
}