namespace OnlineShop.Client.Services.CartService;

public class CartService : ICartService
{
    public event Action? OnChange;
    
    private readonly ILocalStorageService _localStorage;

    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task AddToCartAsync(CartItem cartItem)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        cart.Add(cartItem);

        await _localStorage.SetItemAsync("cart", cart);
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        return cart;
    }
}