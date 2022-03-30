namespace OnlineShop.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly ICartService _cartService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(DataContext context, ICartService cartService, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _cartService = cartService;
        _httpContextAccessor = httpContextAccessor;
    }

    private int GetUserId() =>
        int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    
    public async Task<ServiceResponse<bool>> PlaceOrderAsync()
    {
        var products = (await _cartService.GetDbCartProductsAsync()).Data;
        var totalPrice = 0.00m;
        var orderItems = new List<OrderItem>();

        products.ForEach(x => totalPrice += x.Price * x.Quantity);
        products.ForEach(x => orderItems.Add(new OrderItem
        {
            ProductId = x.ProductId,
            ProductTypeId = x.ProductTypeId,
            Quantity = x.Quantity,
            TotalPrice = x.Price * x.Quantity
        }));

        var order = new Order
        {
            UserId = GetUserId(),
            OrderDate = DateTime.UtcNow,
            TotalPrice = totalPrice,
            OrderItems = orderItems
        };

        _context.Orders.Add(order);
        _context.CartItems.RemoveRange(_context.CartItems.Where(x => x.UserId == GetUserId()));
        
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> {Data = true};
    }
}