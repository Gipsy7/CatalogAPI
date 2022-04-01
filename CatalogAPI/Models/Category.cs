using System.Collections.ObjectModel;

namespace CatalogAPI.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<Product>? Products { get; set; }
}

