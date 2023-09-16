using MyBoardGamesMVC.BusinessLogic;
using MyBoardGamesMVC.BusinessLogic.Interfaces;
using MyBoardGamesMVC.Access;
using MyBoardGamesMVC.Access.Interfaces;

namespace MyBoardGamesMVC {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IGameControl, GameControl>();
            builder.Services.AddTransient<IGameAccess, GameAccess>();
            builder.Services.AddTransient<IGameVersionControl, GameVersionControl>();
            builder.Services.AddTransient<IGameVersionAccess,  GameVersionAccess>();
            builder.Services.AddTransient<IGameCharacterControl, GameCharacterControl>();
            builder.Services.AddTransient<IGameCharacterAccess, GameCharacterAccess>();
            builder.Services.AddTransient<IMergedModellControl, MergedModelControl>();
            builder.Services.AddTransient<IServiceConnection, ServiceConnection>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
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