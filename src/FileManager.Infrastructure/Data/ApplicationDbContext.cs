using System.Reflection;
using FileManager.Domain.Entities;
using FileManager.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private static readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationDbContext)
        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

    private readonly IHttpContextAccessor _contextAccessor;
    public DbSet<User> Users;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor)
        : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddModels();
        AddSafeDeleteGlobalQuery(builder);
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
    {
        builder.Entity<T>().HasQueryFilter(e => e.RecStatus.Equals('A'));
    }

    private void AddSafeDeleteGlobalQuery(ModelBuilder builder)
    {
        foreach (var type in builder.Model.GetEntityTypes())
        {
            if (type.BaseType != null || !typeof(ISoftDelete).IsAssignableFrom(type.ClrType)) continue;
            var method = SetGlobalQueryMethod.MakeGenericMethod(type.ClrType);
            method.Invoke(this, new object[] { builder });
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;
            if (entry.State != EntityState.Deleted || entity is not ISoftDelete) continue;
            entry.State = EntityState.Modified;
            entity.GetType().GetProperty("RecStatus")?.SetValue(entity, 'D');
        }

        BeforeSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;
            if (entry.State != EntityState.Deleted || entity is not ISoftDelete) continue;
            entry.State = EntityState.Modified;
            entry.GetType().GetProperty("RecStatus")?.SetValue(entity, 'D');
        }

        BeforeSaveChanges();
        return base.SaveChanges();
    }

    private void BeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var changedEntries = ChangeTracker.Entries().Where(x =>
            x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);
        foreach (var model in changedEntries)
            switch (model.State)
            {
                case EntityState.Added:
                    if (model.Entity is IRecordInfo recordInfo)
                    {
                        var id = _contextAccessor.HttpContext?.User?.FindFirst("Id").Value;
                        recordInfo.RecUser = Users.Find(id);
                    }

                    break;
            }
    }
}