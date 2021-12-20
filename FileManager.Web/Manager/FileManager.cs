using System.Threading.Tasks;
using System.Transactions;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Entities;
using FileManager.Helpers.Interfaces;
using FileManager.Web.Manager.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileManager.Web.Manager
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

        public async Task SaveFileInfo(IFormFile file, string fileName)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var fileInfo = await _fileHelper.SaveImage(file, fileName);
            await _fileRecordService.RecordFileLog(fileInfo);
            tsc.Complete();
        }

        public async Task RemoveFileInfo(FileRecordInfo fileRecord)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _fileRecordService.RemoveFileRecord(fileRecord);
            _fileHelper.RemoveImage(fileRecord.Name);
            tsc.Complete();
        }
    }
}