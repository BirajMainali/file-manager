#nullable enable
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Extension;
using FileManager.Models;
using FileManager.Web.Manager;
using FileManager.Web.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IFileRecordInfoRepository _recordRepository;
        private readonly INotyfService _notyf;

        public HomeController(IFileManager fileManager, IFileRecordInfoRepository recordRepository, INotyfService notyf)
        {
            _fileManager = fileManager;
            _recordRepository = recordRepository;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
            => View(await _recordRepository.GetAllAsync());

        public IActionResult New() => View();

        [HttpPost]
        public async Task<IActionResult> New(IFormFile file, string name)
        {
            try
            {
                if (file.IsFile()) throw new Exception("Invalid file type.");
                await _fileManager.SaveFileInfo(file, name);
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