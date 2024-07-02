using Microsoft.EntityFrameworkCore;
using netCoreMVC.Models;
using System.Diagnostics;
using Newtonsoft.Json.Serialization;
using netCoreMVC.Utils;
using log4net.Repository;
using log4net;
using log4net.Config;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        builder.Services.AddSingleton<ConsoleDemo>();
        builder.Services.AddHttpContextAccessor();
        var connectionString = builder.Configuration.GetConnectionString("ConStr");
        builder.Services.AddDbContext<ModelContext>(options =>
                  options.UseOracle(connectionString));
        // 全局配置 log4net
        ILoggerRepository repository = LogManager.CreateRepository("LogRepository");
        // 读取配置文件
        XmlConfigurator.Configure(repository, new FileInfo("Config/log4net.config"));
        // XmlConfigurator.ConfigureAndWatch(new FileInfo("Config/log4net.config"));

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });

        log4net.Config.XmlConfigurator.Configure();
        log4net.Config.XmlConfigurator.Configure(new FileInfo("Config/log4net.config"));
        Debug.WriteLine("Log4net configured.");
        #region JWT

        /*  builder.Services.AddAuthentication(options =>
          {
              options.DefaultAuthenticateScheme = "Auth";
              options.DefaultChallengeScheme = "Auth";
          })
  .AddJwtBearer("Auth", options =>
  {
      // JWT 配置项...
  });*/
       
        /*builder.Services.AddControllers(options =>
        {
            options.Filters.Add<Auth>();
        });*/
        #endregion
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseCors("AllowAll"); // 配置 CORS 中间件
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
     

        /*app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        */
        app.Run();
    }

}