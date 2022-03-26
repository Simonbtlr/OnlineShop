namespace OnlineShop.Client.Services.CartService;

public class CartService : ICartService
{
    public event Action? OnChange;
    
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;

    public CartService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
    }

    public async Task AddToCartAsync(CartItem cartItem)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        cart.Add(cartItem);

        await _localStorage.SetItemAsync("cart", cart);
        OnChange?.Invoke();
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        return cart;
    }

    public async Task<List<CartProductResponse>> GetCartProductsAsync()
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartProductResponse>>("cart");
        var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
        
        return cartProducts.Data;
    }
}