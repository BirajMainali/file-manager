using FileManager.Application.Repository.Base;
using FileManager.Application.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository
{
    public class FileCategoryRepository : BaseRepository<FileCategory>, IFileCategoryRepository
    {
        public FileCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}