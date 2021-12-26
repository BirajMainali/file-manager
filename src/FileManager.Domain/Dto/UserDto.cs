using FileManager.Domain.Entities;

namespace FileManager.Domain.Dto;

public class UserDto
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public Organization Organization { get; set; }
}