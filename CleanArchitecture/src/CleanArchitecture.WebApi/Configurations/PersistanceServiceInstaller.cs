using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        services.AddAutoMapper(typeof
            (CleanArchitecture.Persistance.AssemblyReference).Assembly);

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<User, Role>(
        // opsiyonel olarak buraya da password ile ilgili kontroller yazılabilir.
        //    options =>
        //{
        //    options.Password.RequireNonAlphanumeric = false;
        //    options.Password.RequiredLength = 3;
        //    options.Password.RequireUppercase = false;
        //}
        ).AddEntityFrameworkStores<ApplicationDbContext>();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
            connectionString: configuration.GetConnectionString("DefaultConnection"),
            tableName: "Logs",
            autoCreateSqlTable: true)
            .CreateLogger();

        hostBuilder.UseSerilog();
    }
}
