namespace OnlineShop.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;
    private readonly IAuthService _authService;

    public CartService(DataContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
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
        cartItems.ForEach(x => x.UserId = _authService.GetUserId());
        _context.CartItems.AddRange(cartItems);
        await _context.SaveChangesAsync();

        return await GetDbCartProductsAsync();
    }

    public async Task<ServiceResponse<int>> GetCartItemsCountAsync()
    {
        var count = (await _context.CartItems.Where(x => x.UserId == _authService.GetUserId()).ToListAsync()).Count;
        return new ServiceResponse<int> { Data = count };
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProductsAsync()
    {
        return await GetCartProductsAsync(
            await _context.CartItems.Where(x => x.UserId == _authService.GetUserId()).ToListAsync());
    }

    public async Task<ServiceResponse<bool>> AddToCartAsync(CartItem cartItem)
    {
        cartItem.UserId = _authService.GetUserId();

        var sameItem = await _context.CartItems.FirstOrDefaultAsync(x => 
            x.ProductId == cartItem.ProductId && 
            x.ProductTypeId == cartItem.ProductTypeId && 
            x.UserId == cartItem.UserId);

        if (sameItem is null)
            _context.CartItems.Add(cartItem);
        else
            sameItem.Quantity += cartItem.Quantity;

        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<bool>> UpdateQuantityAsync(CartItem cartItem)
    {
        var dbCartItem = await _context.CartItems.FirstOrDefaultAsync(x => 
            x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId &&
            x.UserId == _authService.GetUserId());

        if (dbCartItem is null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Data = false, 
                Message = "Предмет в корзине не существует."
            };
        }

        dbCartItem.Quantity = cartItem.Quantity;
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<bool>> RemoveItemFromCartAsync(int productId, int productTypeId)
    {
        var dbCartItem = await _context.CartItems.FirstOrDefaultAsync(x =>
            x.ProductId == productId && x.ProductTypeId == productTypeId &&
            x.UserId == _authService.GetUserId());

        if (dbCartItem is null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Data = false, 
                Message = "Предмет в корзине не существует."
            };
        }

        _context.CartItems.Remove(dbCartItem);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true };
    }
}