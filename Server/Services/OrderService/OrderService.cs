namespace OnlineShop.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly ICartService _cartService;
    private readonly IAuthService _authService;

    public OrderService(DataContext context, ICartService cartService, IAuthService authService)
    {
        _context = context;
        _cartService = cartService;
        _authService = authService;
    }
    
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
            UserId = _authService.GetUserId(),
            OrderDate = DateTime.UtcNow,
            TotalPrice = totalPrice,
            OrderItems = orderItems
        };

        _context.Orders.Add(order);
        _context.CartItems.RemoveRange(
            _context.CartItems.Where(x => x.UserId == _authService.GetUserId()));
        
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> {Data = true};
    }
}