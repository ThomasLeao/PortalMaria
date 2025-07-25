
using Microsoft.EntityFrameworkCore;
using PortalMaria.Models;
using PortalMaria.Services.Implementations;
using PortalMaria.Services.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;


namespace PortalMaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IAlunoService, AlunoService>();
            builder.Services.AddScoped<IHorarioAlunoService, HorarioAlunoService>();
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
