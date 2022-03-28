namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProductsAsync(
        List<CartItem> cartItems)
    {
        var result = await _cartService.GetCartProductsAsync(cartItems);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItemsAsync(
        List<CartItem> cartItems)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var result = await _cartService.StoreCartItemsAsync(cartItems, userId);
        
        return Ok(result);
    }
}