using HHD.Service.DTOs.Categories.Orders;
using HHD.Service.DTOs.Users.Auth.UserRoles;

namespace HHD.Service.DTOs.Users;

public class UserForResultDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public Guid RoleId { get; set; }

    public IEnumerable<UserRoleForResultDto> UserRoles { get; set; }
    public IEnumerable<OrderForResultDto> Orders { get; set; }
}
