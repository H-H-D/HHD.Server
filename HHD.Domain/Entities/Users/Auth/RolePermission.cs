using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users.Auth;

public class RolePermission : Auditable
{

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; }
}
