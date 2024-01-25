using HHD.Domain.Entities.Commons;
using System.Text.Json.Serialization;

namespace HHD.Domain.Entities.Users.Auth;


public class Role : Auditable
{
    public string Name { get; set; }

    [JsonIgnore]
    public IEnumerable<UserRole> UserRoles { get; set; }
}