namespace HHD.Domain.Entities.Users;

public class UserInfoVerificationCode : VerificationCode
{
    public Guid UserId { get; set; }
    public User User { get; set; }
}
