using HHD.Domain.Entities.Commons;
using HHD.Domain.Entities.Users;

namespace HHD.Domain.Entities.Categories;

public class Commentary : Auditable
{
    public string Comment { get; set; }
    public bool IsLiked { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
