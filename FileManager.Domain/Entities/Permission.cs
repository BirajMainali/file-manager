using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities;

public class Permission : BaseEntity, ISoftDelete
{
    public List<string>? PermissionTypes { get; protected set; }
    public User User { get; protected set; }
    public long UserId { get; set; }


    protected Permission()
    {
    }

    public Permission(List<string> permissionTypes, User user)
    {
        PermissionTypes = permissionTypes;
        User = user;
    }
}