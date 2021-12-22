namespace FileManager.Domain.ValueObject
{
    public class FileRecordVo
    {
        public string Identity { get; set; }
        public string Path { get; set; }
        public double Size { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public Entities.User.User User { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
    }
}