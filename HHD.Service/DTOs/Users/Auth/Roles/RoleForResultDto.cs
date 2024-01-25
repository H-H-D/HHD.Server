using HHD.Service.DTOs.Users.Auth.UserRoles;

namespace HHD.Service.DTOs.Users.Auth.Roles;

public class RoleForResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<UserRoleForResultDto> UserRoles { get; set; }
}
