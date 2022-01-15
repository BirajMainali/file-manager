using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services.Interface;
using FileManager.Domain.Dto;
using FileManager.Web.Providers.Interfaces;
using FileManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers;

public class FileCategoryController : Controller
{
    private readonly IFileCategoryRepository _fileCategoryRepository;
    private readonly IFileCategoryService _fileCategoryService;
    private readonly INotyfService _notyf;
    private readonly ICurrentUserProvider _userProvider;

    public FileCategoryController(IFileCategoryRepository fileCategoryRepository,
        IFileCategoryService fileCategoryService, INotyfService notyf, ICurrentUserProvider userProvider)
    {
        _fileCategoryRepository = fileCategoryRepository;
        _fileCategoryService = fileCategoryService;
        _notyf = notyf;
        _userProvider = userProvider;
    }

    public async Task<IActionResult> Index()
    {
        var organization = await _userProvider.GetCurrentOrganization();
        return View(await _fileCategoryRepository.GetAllAsync(x => x.OrganizationId == organization.Id));
    }

    public IActionResult New()
        => View(new FileCategoryVm());

    [HttpPost]
    public async Task<IActionResult> New(FileCategoryVm categoryVm)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryVm);
        }

        try
        {
            var organization = await _userProvider.GetCurrentOrganization();
            var dto = new FileCategoryDto(organization, categoryVm.Name, categoryVm.Description, categoryVm.Priority);
            await _fileCategoryService.Create(dto);
            _notyf.Success($"New file category #{dto.Name} added");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            _notyf.Error(e.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> Edit(long id)
    {
        try
        {
            var fileCategory = await _fileCategoryRepository.FindOrThrowAsync(id);
            var vm = new FileCategoryVm()
            {
                Name = fileCategory.Name,
                Description = fileCategory.Description,
                Priority = fileCategory.Priority,
            };
            return View(vm);
        }
        catch (Exception e)
        {
            _notyf.Error(e.Message);
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, FileCategoryVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        try
        {
            var fileCategory = await _fileCategoryRepository.FindOrThrowAsync(id);
            var dto = new FileCategoryDto(fileCategory.Organization, vm.Name, vm.Description, vm.Priority);
            await _fileCategoryService.Update(fileCategory, dto);
            _notyf.Success($"#{fileCategory.Name} updated");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            _notyf.Error(e.Message);
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Remove(long id)
    {
        try
        {
            var fileCategory = await _fileCategoryRepository.FindOrThrowAsync(id);
            await _fileCategoryService.Remove(fileCategory);
            _notyf.Success("Category moved to trash");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            _notyf.Error(e.Message);
            return RedirectToAction("Index");
        }
    }
}