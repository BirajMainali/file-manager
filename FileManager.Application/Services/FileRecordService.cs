using System.Transactions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Entities;
using FileManager.Domain.ValueObject;

namespace FileManager.Application.Services
{
    public class FileRecordService : IFileRecordService
    {
        private readonly IFileRecordInfoRepository _recordInfoRepository;


        public FileRecordService(IFileRecordInfoRepository recordInfoRepository)
        {
            _recordInfoRepository = recordInfoRepository;
        }

        public async Task RecordFileLog(FileRecordVo vo)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var fileInfo = new FileRecordInfo(vo.Extension,vo.Identity, vo.User, vo.FileName, vo.ContentType, vo.Path, vo.Size);
            await _recordInfoRepository.CreateAsync(fileInfo);
            await _recordInfoRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task RemoveFileRecord(FileRecordInfo fileRecord)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _recordInfoRepository.Remove(fileRecord);
            await _recordInfoRepository.FlushAsync();
            tsc.Complete();
        }
    }
}