namespace OnlineShop.Client.Services.CartService;

public class CartService : ICartService
{
    public event Action? OnChange;
    
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;

    private const string Key = "cart";

    public CartService(ILocalStorageService localStorage, HttpClient httpClient, AuthenticationStateProvider authStateProvider)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
    }

    public async Task AddToCartAsync(CartItem cartItem)
    {
        if ((await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated)
            Console.WriteLine("Пользователь авторизован");
        else
            Console.WriteLine("Пользователь не авторизован");
        
        var cart = await _localStorage.GetItemAsync<List<CartItem>>(Key) ?? new List<CartItem>();

        var sameItem = 
            cart.Find(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId);

        if (sameItem is null)
            cart.Add(cartItem);
        else
            sameItem.Quantity += cartItem.Quantity;

        await _localStorage.SetItemAsync("cart", cart);
        OnChange?.Invoke();
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>(Key) ?? new List<CartItem>();

        return cart;
    }

    public async Task<List<CartProductResponse>> GetCartProductsAsync()
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartProductResponse>>(Key);
        var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
        
        return cartProducts.Data;
    }

    public async Task RemoveProductsFromCartAsync(int productId, int productTypeId)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>(Key);
        
        if (cart is null) return;

        var cartItem = cart.Find(x => x.ProductId == productId && x.ProductTypeId == productTypeId);

        if (cartItem is not null)
        {
            cart.Remove(cartItem);
            await _localStorage.SetItemAsync(Key, cart);
            OnChange?.Invoke();
        }
    }

    public async Task UpdateQuantityAsync(CartProductResponse product)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>(Key);
        
        if (cart is null) return;

        var cartItem = 
            cart.Find(x => x.ProductId == product.ProductId && x.ProductTypeId == product.ProductTypeId);

        if (cartItem is not null)
        {
            cartItem.Quantity = product.Quantity;
            await _localStorage.SetItemAsync(Key, cart);
        }
    }
}