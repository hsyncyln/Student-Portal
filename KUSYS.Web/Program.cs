using KUSYS.Core.Helper;
using KUSYS.Core.Implementations;
using KUSYS.Core.Services;
using KUSYS.Domain.DBContext;
using KUSYS.Web.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("KUSYSDBConnection");
builder.Services.AddDbContext<KUSYSDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ICourseService,CourseService>();

builder.Services.AddScoped<ILogHelper, LogHelper>();

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

app.UseCustomMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
