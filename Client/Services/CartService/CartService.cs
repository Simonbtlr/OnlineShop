namespace OnlineShop.Client.Services.CartService;

public class CartService : ICartService
{
    public event Action? OnChange;
    
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;

    private const string Key = "cart";

    public CartService(ILocalStorageService localStorage, HttpClient httpClient, 
        AuthenticationStateProvider authStateProvider)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
    }

    public async Task AddToCartAsync(CartItem cartItem)
    {
        if (await IsUserAuthenticated())
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
        await GetCartItemsCountAsync();
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        await GetCartItemsCountAsync();
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
            await GetCartItemsCountAsync();
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

    public async Task StoreCartItemsAsync(bool emptyLocalCart = false)
    {
        var localCart = await _localStorage.GetItemAsync<List<CartItem>>(Key);

        if (localCart is null)
            return;

        await _httpClient.PostAsJsonAsync("api/cart", localCart);

        if (emptyLocalCart)
            await _localStorage.RemoveItemAsync(Key);
    }

    public async Task GetCartItemsCountAsync()
    {
        if (await IsUserAuthenticated())
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
            var count = result.Data;

            await _localStorage.SetItemAsync("cartItemsCount", count);
        }
        else
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>(Key);
            await _localStorage.SetItemAsync("cartItemsCount", cart?.Count ?? 0);
        }
    }

    private async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}