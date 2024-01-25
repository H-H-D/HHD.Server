namespace HHD.Service.DTOs.Users.Auth.AccessTokens;

public class AccessTokenForCreationDto
{
    public string Token { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsRevoked { get; set; }

    public Guid UserId { get; set; }
}
