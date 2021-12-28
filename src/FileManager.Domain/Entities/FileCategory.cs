using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities;

public class FileCategory : BaseEntity, ISoftDelete, IRecordInfo
{
    public string Name { get; protected set; }
    public string? Description { get; protected set; }
    public virtual Organization Organization { get; protected set; }
    public long OrganizationId { get; set; }
    public long? Priority { get; set; }
    public virtual User RecUser { get; set; }
    public long RecUserId { get; set; }


    protected FileCategory()
    {

    }
    public FileCategory(string name, string description, Organization organization, long priotity)
        => Copy(name, description, organization, priotity);

    public void Update(string name, string description, Organization organization, long priotity)
        => Copy(name, description, organization, priotity);

    private void Copy(string name, string description, Organization organization, long priotity)
    {
        Name = name;
        Description = description;
        Organization = organization;
        Priority = priotity;
    }
}