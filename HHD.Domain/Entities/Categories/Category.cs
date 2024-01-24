using HHD.Domain.Entities.Commons;

namespace HHD.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
