using HHD.Domain.Entities.Commons;
using System.Text.Json.Serialization;

namespace HHD.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }

    [JsonIgnore]
    public IEnumerable<Product> Products { get; set; }
}
