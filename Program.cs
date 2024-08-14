using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Models;
using Infrastrcuture.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace MVC_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var con = builder.Configuration.GetConnectionString("cString");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("con"));

            //builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            
            builder.Services.AddScoped<IBaseRepository<ServiceModel>, BaseRepository<ServiceModel>>();
            builder.Services.AddScoped<IBaseRepository<BlogPost>, BaseRepository<BlogPost>>();

            builder.Services.AddSingleton(new SmtpClient
            {
                Host = "smtp.example.com",
                Port = 465,
                Credentials = new System.Net.NetworkCredential("malikvm@code.edu.az", "shrd efez unsn powv"),
                EnableSsl = true,
            });

            builder.Services.AddScoped<IServiceServise, ServiceService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IBlogPostService, BlogPostService>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
