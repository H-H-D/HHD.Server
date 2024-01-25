namespace HHD.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}
