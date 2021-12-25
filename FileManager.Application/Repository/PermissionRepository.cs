using FileManager.Application.Repository.Base;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Application.Repository;

public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(DbContext context) : base(context)
    {
    }
}