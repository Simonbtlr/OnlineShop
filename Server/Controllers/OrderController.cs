namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrdersAsync()
    {
        var result = await _orderService.GetOrdersAsync();
        
        return result;
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetOrderDetilsAsync(int orderId)
    {
        var result = await _orderService.GetOrderDetailsAsync(orderId);
        
        return result;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrderAsync()
    {
        var result = await _orderService.PlaceOrderAsync();

        return Ok(result);
    }
}