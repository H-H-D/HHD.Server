using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users.Auth;

public class Permission : Auditable
{
    public string Name { get; set; }
    public IEnumerable<RolePermission> RolePermissions { get; set; }
}
