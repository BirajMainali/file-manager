namespace FileManager.Domain.Entities.Interfaces
{
    public interface IRecordInfo
    {
        public User RecUser { get; set; }
        public long RecUserId { get; set; }
    }
}