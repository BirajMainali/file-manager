using AspNetCoreHero.ToastNotification;
using FileManager.Application.Helper;
using FileManager.Application.Helper.Interfaces;
using FileManager.Infrastructure;
using FileManager.Infrastructure.Data;
using FileManager.Web.Manager;
using FileManager.Web.Manager.Interfaces;
using FileManager.Web.Providers;
using FileManager.Web.Providers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileManager.Web;

public static class DiConfig
{
    public static IServiceCollection UseConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.UseAppDiConfiguration();
        services.AddScoped<IFileHelper, FileHelper>();
        services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        services.AddHttpContextAccessor();
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x => { x.LoginPath = "/Login"; });
        services.AddNotyf(config =>
        {
            config.DurationInSeconds = 10;
            config.IsDismissable = true;
            config.Position = NotyfPosition.BottomRight;
        });
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("FileManager.Web")));
        return services;
    }
}