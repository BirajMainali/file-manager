using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities
{
    public class FileRecordInfo : BaseEntity, ISoftDelete, IRecordInfo
    {
        public string Extension { get; protected set; }
        public string Name { get; protected set; }
        public string ContentType { get; protected set; }
        public string Identity { get; protected set; }
        public virtual Organization Organization { get; set; }
        public long OrganizationId { get; set; }
        public string Path { get; protected set; }
        public double Size { get; protected set; }

        protected FileRecordInfo()
        {
        }

        public FileRecordInfo(string extension, string identity, Organization organization, string name, string contentType,
            string path, double size)
        {
            Extension = extension;
            Identity = identity;
            Name = name;
            ContentType = contentType;
            Path = path;
            Size = size;
        }

        public User.User RecUser { get; set; }
        public long RecUserId { get; set; }
    }
}