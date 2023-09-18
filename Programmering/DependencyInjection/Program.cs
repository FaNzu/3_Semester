using DependencyInjection.Controllers;
using DependencyInjection.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using DependencyInjection.Data;
//using DependencyInjection.Data;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //if(!builder.Environment.IsDevelopment()) // hvis builder er i debug, s� add scope s� vi ogs� har vores dependency injection
            //{
            //    builder.Services.AddScoped<IDummyService,DummyService>(); //s� l�nge scope er t�ndt
            //}

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