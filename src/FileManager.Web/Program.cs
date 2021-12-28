using System.IO;
using FileManager.Application.Constants;
using FileManager.Web;
using FileManager.Web.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.UseConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new CustomFileProvider(Path.Combine(builder.Environment.ContentRootPath, Constant.Content)),
    RequestPath = "/Content"
});
app.Services.CreateScope().ServiceProvider.GetService<DbContext>()?.Database.Migrate();
app.ConfigurePipeline();
app.Run();