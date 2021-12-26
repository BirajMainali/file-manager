using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Services.Interface;

public interface IUserService
{
    Task<User> CreateUser(UserDto dto);
    Task Update(User user, UserDto dto);
    Task Remove(User user);
}