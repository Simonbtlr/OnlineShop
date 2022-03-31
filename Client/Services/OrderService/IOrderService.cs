namespace OnlineShop.Client.Services.OrderService;

public interface IOrderService
{
    Task PlaceOrderAsync();
    Task<List<OrderOverviewResponse>> GetOrdersAsync();
}