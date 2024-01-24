using HHD.Domain.Entities.Commons;
using HHD.Domain.Entities.Users;
using HHD.Domain.Enums;

namespace HHD.Domain.Entities.Categories;

public class Order : Auditable
{
    public int Count { get; set; }
    public OrderType OrderType { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}

