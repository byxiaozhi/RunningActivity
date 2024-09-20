using Microsoft.EntityFrameworkCore;
using RunningActivity.Components;
using RunningActivity.Models;

namespace RunningActivity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            RegisterServices(builder);
            var app = builder.Build();
            MigrateDatabase(app);
            ConfigureRequestPipeline(app);
            app.Run();
        }

        private static void RegisterServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddRazorComponents().AddInteractiveServerComponents();
            services.AddBootstrapBlazor();
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void MigrateDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();
        }

        private static void ConfigureRequestPipeline(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        }
    }
}
