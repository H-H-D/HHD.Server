using HHD.Domain.Enums;

namespace HHD.Service.DTOs.Categories.Orders;

public class OrderForUpdateDto
{
    public int Count { get; set; }
    public OrderType OrderType { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
