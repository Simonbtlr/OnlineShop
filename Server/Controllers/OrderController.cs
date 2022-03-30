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

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrderAsync()
    {
        var result = await _orderService.PlaceOrderAsync();

        return Ok(result);
    }
}