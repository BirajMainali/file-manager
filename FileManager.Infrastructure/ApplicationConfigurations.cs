using FileManager.Application.Manager;
using FileManager.Application.Manager.Interfaces;
using FileManager.Application.Providers;
using FileManager.Application.Providers.Interfaces;
using FileManager.Application.Repository;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Services;
using FileManager.Application.Services.Interface;
using FileManager.Application.Validator;
using FileManager.Application.Validator.Interfaces;
using FileManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileManager.Infrastructure
{
    public static class ApplicationDbConfigurations
    {
        public static IServiceCollection UseAppDiConfiguration(this IServiceCollection services)
        {
            UseServices(services);
            UseMisc(services);
            UseRepos(services);
            UseManager(services);
            return services;
        }

        private static void UseRepos(IServiceCollection service)
            => service.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFileRecordInfoRepository, FileRecordInfoRepository>()
                .AddScoped<IOrganizationRepository, OrganizationRepository>();

        private static void UseServices(IServiceCollection service)
            => service.AddScoped<IUserService, UserService>()
                .AddScoped<IFileRecordService, FileRecordService>()
                .AddScoped<IOrganizationService, OrganizationService>();

        private static void UseMisc(IServiceCollection service)
            => service.AddScoped<ISqlConnectionProvider, SqlConnectionProvider>()
                .AddScoped<DbContext, ApplicationDbContext>()
                .AddScoped<IUserValidator, UserValidator>()
                .AddScoped<IOrganizationValidator, OrganizationValidator>();

        private static void UseManager(IServiceCollection services)
            => services.AddScoped<IOrganizationUserManager, OrganizationUserManager>()
                .AddScoped<IFileManager, Application.Manager.FileManager>();
    }
}