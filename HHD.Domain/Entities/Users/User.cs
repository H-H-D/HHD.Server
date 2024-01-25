using HHD.Domain.Entities.Categories;
using HHD.Domain.Entities.Commons;
using HHD.Domain.Entities.Users.Auth;

namespace HHD.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public IEnumerable<UserRole> UserRoles { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}
