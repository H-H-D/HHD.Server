using HHD.Service.DTOs.Categories.Products;

namespace HHD.Service.DTOs.Categories;

public class CategoryForResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ProductForResultDto> Products { get; set; }
}
