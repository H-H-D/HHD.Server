using HHD.Domain.Entities.Categories;
using HHD.Domain.Entities.Users;

namespace HHD.Service.DTOs.Categories.Commentaries;

public class CommentaryForCreationDto
{
    public string Comment { get; set; }
    public bool IsLiked { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
