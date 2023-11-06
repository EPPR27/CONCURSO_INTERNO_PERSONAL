using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using CONCURSO_INTERNO_PERSONAL.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SmvConcursoInternoContext>
    (
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))
    );

var context = new CustomAssamblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "LibreriaPDF/libwkhtmltox.dll"));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ContratacionPersonal}/{action=TablaContratPersonal}/{id?}");

app.Run();
