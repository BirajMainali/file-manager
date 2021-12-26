using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities;

public class Permission : BaseEntity, ISoftDelete
{
    protected Permission()
    {
    }

    public Permission(List<string> permissionTypes, User user)
    {
        PermissionTypes = permissionTypes;
        User = user;
    }

    public List<string>? PermissionTypes { get; protected set; }
    public virtual User User { get; protected set; }
    public long UserId { get; set; }
}