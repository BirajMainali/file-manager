using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Dto;

public record FileInfoRecordDto(Organization Organization, FileCategory FileCategory, string FileName, IFormFile File, string? Description);