using Base.Entities;

namespace FileManager.Domain.Entities
{
    public class FileRecordInfo : BaseEntity
    {
        public string Name { get; protected set; }
        public string ContentType { get; protected set; }
        public string Path { get; protected set; }
        public double Size { get; protected set; }

        protected FileRecordInfo()
        {
        }

        public FileRecordInfo(string name, string contentType, string path, double size)
        {
            Name = name;
            ContentType = contentType;
            Path = path;
            Size = size;
        }
    }
}