using HHD.Domain.Entities.Commons;
using HHD.Domain.Enums;
using System.Text.Json.Serialization;

namespace HHD.Domain.Entities.Users.Auth;


public class Role : Auditable
{
    public RoleType RoleType { get; set; }

    [JsonIgnore]
    public IEnumerable<UserRole> UserRoles { get; set; }
}