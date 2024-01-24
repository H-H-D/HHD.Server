using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users.Auth;

public class UserRole : Auditable
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
