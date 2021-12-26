using FileManager.Domain.Entities;
using FileManager.Domain.ValueObject;

namespace FileManager.Application.Services.Interface;

public interface IFileRecordService
{
    Task RecordFileLog(FileRecordVo vo);
    Task RemoveFileRecord(FileRecordInfo fileRecord);
}