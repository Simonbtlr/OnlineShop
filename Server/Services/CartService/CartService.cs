namespace OnlineShop.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<CartItem> cartItems)
    {
        var result = new ServiceResponse<List<CartProductResponse>>
        {
            Data = new List<CartProductResponse>()
        };

        foreach (var cartItem in cartItems)
        {
            var product = await _context.Products
                .Where(x => x.Id == cartItem.ProductId)
                .FirstOrDefaultAsync();
            
            if (product is null)
                continue;

            var productVariant = await _context.ProductVariants
                .Where(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId)
                .Include(x => x.ProductType)
                .FirstOrDefaultAsync();
            
            if (productVariant is null)
                continue;

            var cartProduct = new CartProductResponse
            {
                ProductId = product.Id,
                Title = product.Title,
                ImageUrl = product.ImageUrl,
                Price = productVariant.Price,
                ProductType = productVariant.ProductType.Name,
                ProductTypeId = productVariant.ProductTypeId,
                Quantity = cartItem.Quantity
            };
            
            result.Data.Add(cartProduct);
        }

        return result;
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItemsAsync(List<CartItem> cartItems)
    {
        cartItems.ForEach(x => x.UserId = GetUserId());
        _context.CartItems.AddRange(cartItems);
        await _context.SaveChangesAsync();

        return await GetCartProductsAsync(
            await _context.CartItems.Where(x => x.UserId == GetUserId()).ToListAsync());
    }

    public async Task<ServiceResponse<int>> GetCartItemsCountAsync()
    {
        var count = (await _context.CartItems.Where(x => x.UserId == GetUserId()).ToListAsync()).Count;
        return new ServiceResponse<int> { Data = count };
    }

    private int GetUserId() =>
        int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
}