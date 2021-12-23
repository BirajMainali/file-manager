#nullable enable
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Dto;
using FileManager.Models;
using FileManager.Web.Extension;
using FileManager.Web.Providers.Interfaces;
using FileManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IFileRecordInfoRepository _recordRepository;
        private readonly INotyfService _notyf;
        private readonly ICurrentUserProvider _currentUserProvider;

        public HomeController(IFileManager fileManager, IFileRecordInfoRepository recordRepository, INotyfService notyf, ICurrentUserProvider currentUserProvider)
        {
            _fileManager = fileManager;
            _recordRepository = recordRepository;
            _notyf = notyf;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<IActionResult> Index()
            => View(await _recordRepository.GetAllAsync());

        public IActionResult New() => View(new FileUploadVm());

        [HttpPost]
        public async Task<IActionResult> New(FileUploadVm vm)
        {
            try
            {
                if (vm.File.IsFile()) throw new Exception("Invalid file type.");
                var organization = await _currentUserProvider.GetCurrentOrganization();
                await _fileManager.SaveFileInfo(new FileInfoRecordDto(organization,vm.FileName,vm.File,vm.Description));
                _notyf.Success("File Added");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var fileRecord = await _recordRepository.FindOrThrowAsync(id);
                await _fileManager.RemoveFileInfo(fileRecord);
                _notyf.Success("File Removed");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _notyf.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}