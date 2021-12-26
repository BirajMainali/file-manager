using FileManager.Domain.Dto;
using FileManager.Domain.Entities;

namespace FileManager.Application.Manager.Interfaces;

public interface IFileManager
{
    Task SaveFileInfo(FileInfoRecordDto dto);
    Task RemoveFileInfo(FileRecordInfo record);
}