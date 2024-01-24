using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users;

public class UserCredentials : Auditable
{
    public string Password { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
