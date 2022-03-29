using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Shared.Models.Shop;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    
    // OrderItem
    public List<OrderItem> OrderItems { get; set; }

    // User
    public int UserId { get; set; }
}