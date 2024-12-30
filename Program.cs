using day2.Models;
using day2.Repositry;
using day2.SpecialCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(option =>
{
  //  option.Filters.Add(new AuthorizeFilter());
});
builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDatabase"));
});



builder.Services.AddScoped<ICourse, Coursess>();
builder.Services.AddScoped<IInstructors, Instructorss>();
builder.Services.AddScoped<ICourseResult, CourseResultss>();
builder.Services.AddScoped<IDepartment, Departmentss>();
builder.Services.AddScoped<ITrainee, Traineess>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 3;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<Context>();



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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
