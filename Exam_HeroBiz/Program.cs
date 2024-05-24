using HeroBiz_Business.Services.Abstracts;
using HeroBiz_Business.Services.Concretes;
using HeroBiz_Core.Models;
using HeroBiz_Core.RepositoryAbstracts;
using HeroBiz_Data.DAL;
using HeroBiz_Data.RepositoryConcretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exam_HeroBiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
                opt.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-I78A9JH\\SQLEXPRESS01;Database=ExamHeroBiz;Trusted_connection=true;Integrated Security=true;Encrypt=false");
            });

            builder.Services.AddScoped<IOurService, OurServiceSer>();
            builder.Services.AddScoped<IOurServiceRepository, OurServiceRepository>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}