using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Shared.Models.Shop;

public class OrderItem
{
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    
    // ProductType
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }
    
    // Product
    public Product Product { get; set; }
    public int ProductId { get; set; }
    
    // Order
    public Order Order { get; set; }
    public int OrderId { get; set; }
}