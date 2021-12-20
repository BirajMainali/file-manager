namespace FileManager.Models
{
    public class FileRecord
    {
        public long Id { get; protected set; }
        public string Name { get; protected set; }
        public string ContentType { get; protected set; }
        public string Path { get; protected set; }
        public double Size { get; protected set; }

        protected FileRecord()
        {
        }

        public FileRecord(string name, string contentType, string path, double size)
        {
            Name = name;
            ContentType = contentType;
            Path = path;
            Size = size;
        }
    }
}