using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebApi.Coonfigurations;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
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
    }
}
