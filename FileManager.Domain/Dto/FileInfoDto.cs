using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Dto;

public record FileInfoRecordDto(Entities.User.User User, Organization Organization, string FileName, IFormFile File, string? Description);