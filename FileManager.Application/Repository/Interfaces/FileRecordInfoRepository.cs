using FileManager.Application.Repository.Base;
using FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository.Interfaces
{
    public class FileRecordInfoRepository : BaseRepository<FileRecordInfo>, IFileRecordInfoRepository
    {
        public FileRecordInfoRepository(DbContext context) : base(context)
        {
        }
    }
}