namespace CleanArchitecture.WebApi.Coonfigurations;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
