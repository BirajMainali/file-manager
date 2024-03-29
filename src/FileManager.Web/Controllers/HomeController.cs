﻿#nullable enable
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FileManager.Application.Extensions;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.Dto;
using FileManager.Models;
using FileManager.Web.Providers.Interfaces;
using FileManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IFileManager _fileManager;
    private readonly INotyfService _notyf;
    private readonly IFileRecordInfoRepository _recordRepository;
    private readonly IFileCategoryRepository _fileCategoryRepository;

    public HomeController(IFileManager fileManager, IFileRecordInfoRepository recordRepository, INotyfService notyf,
        ICurrentUserProvider currentUserProvider, IFileCategoryRepository fileCategoryRepository)
    {
        _fileCategoryRepository = fileCategoryRepository;
        _fileManager = fileManager;
        _recordRepository = recordRepository;
        _notyf = notyf;
        _currentUserProvider = currentUserProvider;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _recordRepository.GetAllAsync());
    }

    public IActionResult New()
    {
        return View(new FileUploadVm());
    }

    [HttpPost]
    public async Task<IActionResult> New(FileUploadVm vm)
    {
        try
        {
            if (vm.File.IsFile()) throw new Exception("Invalid file type.");
            var organization = await _currentUserProvider.GetCurrentOrganization();
            var fileCategory = await _fileCategoryRepository.FindOrThrowAsync(vm.FileCategoryId);
            await _fileManager.SaveFileInfo(new FileInfoRecordDto(organization, fileCategory, vm.FileName, vm.File, vm.Description));
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