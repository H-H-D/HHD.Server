using HHD.Domain.Entities.Categories;
using HHD.Domain.Entities.Users;

namespace HHD.Service.DTOs.Categories.Products;

public class ProductForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public bool IsFavourite { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SellerId { get; set; }
}
