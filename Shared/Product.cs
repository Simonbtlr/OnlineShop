using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Shared;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool Featured { get; set; }

    // Category
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    
    // ProductVariant
    public List<ProductVariant> Variants { get; set; } = new();
}