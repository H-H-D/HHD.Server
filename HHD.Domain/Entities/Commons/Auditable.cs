namespace HHD.Domain.Entities.Commons;

public class Auditable
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
}
