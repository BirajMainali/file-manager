using Microsoft.AspNetCore.Http;

namespace FileManager.Domain.Dto;

public record FileInfoRecordDto(Entities.User.User User, string FileName, IFormFile File, string? Description);