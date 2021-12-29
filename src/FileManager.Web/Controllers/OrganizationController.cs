using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Repository.Interfaces;
using FileManager.Domain.ValueObject;
using FileManager.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers;

public class OrganizationController : Controller
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly INotyfService _notyfService;
    private readonly IOrganizationUserManager _organizationUserManager;

    public OrganizationController(IOrganizationRepository organizationRepository, INotyfService notyfService,
        IOrganizationUserManager organizationUserManager)
    {
        _organizationRepository = organizationRepository;
        _notyfService = notyfService;
        _organizationUserManager = organizationUserManager;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _organizationRepository.GetAllAsync());
    }

    [AllowAnonymous]
    public IActionResult Register() => View(new OrganizationUserViewModel());

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(OrganizationUserViewModel viewModel)
    {
        try
        {
            //if (!ModelState.IsValid) return View(viewModel);
            var organizationUserVo = new OrganizationUserVo()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Description = viewModel.Description,
                Email = viewModel.Email,
                Fax = viewModel.Fax,
                Gender = viewModel.Gender,
                Password = viewModel.Password,
                Phone = viewModel.Phone,
                Url = viewModel.Url,
                OrgName = viewModel.OrgName
            };
            await _organizationUserManager.CreateOrganization(organizationUserVo);
            _notyfService.Success("success");
            return RedirectToAction("Index", "Login");
        }
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            return View(viewModel);
        }
    }
}