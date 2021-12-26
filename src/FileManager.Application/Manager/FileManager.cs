using System.Transactions;
using FileManager.Application.Helper.Interfaces;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Dto;
using FileManager.Domain.Entities;
using FileManager.Domain.ValueObject;

namespace FileManager.Application.Manager
{
    public class FileManager : IFileManager
    {
        private readonly IFileHelper _fileHelper;
        private readonly IFileRecordService _fileRecordService;

        public FileManager(IFileHelper fileHelper, IFileRecordService fileRecordService)
        {
            _fileHelper = fileHelper;
            _fileRecordService = fileRecordService;
        }

        public async Task SaveFileInfo(FileInfoRecordDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var recordVo = await _fileHelper.SaveImage(dto.File);
            ToRecordInfo(dto, recordVo);
            await _fileRecordService.RecordFileLog(recordVo);
            tsc.Complete();
        }

        public async Task RemoveFileInfo(FileRecordInfo fileRecord)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _fileRecordService.RemoveFileRecord(fileRecord);
            _fileHelper.RemoveImage(fileRecord.Name);
            tsc.Complete();
        }

        private static FileRecordVo ToRecordInfo(FileInfoRecordDto dto, FileRecordVo vo)
        {
            vo.Organization = dto.Organization;
            vo.FileName = dto.FileName;
            vo.Description = dto.Description;
            return vo;
        }
    }
}