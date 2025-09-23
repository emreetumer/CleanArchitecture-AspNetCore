using CleanArchitecture.Application.Features.RoleFeatures.Command.CreateRole;

namespace CleanArchitecture.Application.Services;
public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
}
