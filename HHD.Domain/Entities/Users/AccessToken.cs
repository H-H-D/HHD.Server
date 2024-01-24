using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Users;

public class AccessToken : Auditable
{
    public string Token { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsRevoked { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
