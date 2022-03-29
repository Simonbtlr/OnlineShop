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

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<int>>> GetDbCartProductsAsync()
    {
        var result = await _cartService.GetDbCartProductsAsync();
        
        return Ok(result);
    }

    [HttpGet("count")]
    public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCountAsync()
    {
        return Ok(await _cartService.GetCartItemsCountAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItemsAsync(
        List<CartItem> cartItems)
    {
        var result = await _cartService.StoreCartItemsAsync(cartItems);
        
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<ServiceResponse<bool>>> AddToCartAsync(CartItem cartItem)
    {
        var result = await _cartService.AddToCartAsync(cartItem);
        
        return Ok(result);
    }

    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProductsAsync(
        List<CartItem> cartItems)
    {
        var result = await _cartService.GetCartProductsAsync(cartItems);
        
        return Ok(result);
    }

    [HttpPut("update-quantity")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantityAsync(CartItem cartItem)
    {
        var result = await _cartService.UpdateQuantityAsync(cartItem);

        return Ok(result);
    }

    [HttpDelete("{productId}/{productTypeId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCartAsync(int productId, int productTypeId)
    {
        var result = await _cartService.RemoveItemFromCartAsync(productId, productTypeId);

        return Ok(result);
    }
}