using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users.Auth;


public class Role : Auditable
{
    public string Name { get; set; }
    public IEnumerable<RolePermission> RolePermissions { get; set; }
}