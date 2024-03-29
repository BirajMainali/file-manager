﻿using FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Infrastructure;

public static class EntityRegisterer
{
    public static ModelBuilder AddModels(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("user", "auth");
        modelBuilder.Entity<FileRecordInfo>().ToTable("file_record_info");
        modelBuilder.Entity<Organization>().ToTable("organization");
        modelBuilder.Entity<Permission>().ToTable("permission", "auth");
        modelBuilder.Entity<FileCategory>().ToTable("file_category");
        return modelBuilder;
    }
}