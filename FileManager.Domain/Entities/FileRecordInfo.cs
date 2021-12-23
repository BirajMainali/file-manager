using Base.Entities.Interfaces;
using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities
{
    public class FileRecordInfo : BaseEntity, ISoftDelete
    {
        public string Extension { get; protected set; }
        public string Name { get; protected set; }
        public string ContentType { get; protected set; }
        public string Identity { get; protected set; }
        public virtual User.User User { get; protected set; }
        public long UserId { get; set; }
        public string Path { get; protected set; }
        public double Size { get; protected set; }

        protected FileRecordInfo()
        {
        }

        public FileRecordInfo(string extension, string identity, User.User user, string name, string contentType,
            string path, double size)
        {
            Extension = extension;
            Identity = identity;
            User = user;
            Name = name;
            ContentType = contentType;
            Path = path;
            Size = size;
        }
    }
}