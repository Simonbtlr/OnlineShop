namespace OnlineShop.Server.Services.OrderService;

public interface IOrderService
{
    Task<ServiceResponse<bool>> PlaceOrderAsync();
    Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrdersAsync();
}