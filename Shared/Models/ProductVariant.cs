using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShop.Shared.Models;

public class ProductVariant
{
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalPrice { get; set; }
    
    // Product
    [JsonIgnore]
    public Product Product { get; set; }
    public int ProductId { get; set; }
    
    // ProductType
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }
}