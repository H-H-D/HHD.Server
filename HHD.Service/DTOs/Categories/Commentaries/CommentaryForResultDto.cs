namespace HHD.Service.DTOs.Categories.Commentaries;

public class CommentaryForResultDto
{
    public string Comment { get; set; }
    public bool IsLiked { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}