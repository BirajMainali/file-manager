using FileManager.Domain.Entities;

namespace FileManager.Domain.Dto;

public class PermissionDto
{
    public List<string>? PermissionTypes { get; set; } = new List<string>();
    public User User { get; set; }
}