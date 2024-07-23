using Front_End.Services;
using Front_End.Services.IServices;
using Front_End.Utility;

namespace Front_End
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //agregamos el httpClient para las solicitudes
            builder.Services.AddHttpClient<IMarvelService, MarvelService>();

            //Asignamos configuracion de appsetting.json
            SD.ApiMarvel = builder.Configuration["ServiceUrls:ApiMarvel"];
            builder.Services.AddScoped<IMarvelService, MarvelService>();

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