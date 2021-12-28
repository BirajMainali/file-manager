using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities;

public class FileRecordInfo : BaseEntity, ISoftDelete, IRecordInfo
{
    protected FileRecordInfo()
    {
    }

    public FileRecordInfo(FileCategory fileCategory, string extension, string identity, Organization organization, string name, string contentType,
        string path, double size)
    {
        Extension = extension;
        Identity = identity;
        Name = name;
        ContentType = contentType;
        Path = path;
        Size = size;
        Organization = organization;
        FileCategory = fileCategory;
    }

    public string Extension { get; protected set; }
    public string Name { get; protected set; }
    public string ContentType { get; protected set; }
    public string Identity { get; protected set; }
    public virtual Organization Organization { get; protected set; }
    public long OrganizationId { get; set; }

    public virtual FileCategory FileCategory { get; protected set; }
    public long FileCategoryId { get; set; }
    public string Path { get; protected set; }
    public double Size { get; protected set; }

    public virtual User RecUser { get; set; }
    public long RecUserId { get; set; }
}