namespace OnlineShop.Client.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCartAsync(CartItem cartItem);
    Task<List<CartProductResponse>> GetCartProductsAsync();
    Task RemoveProductsFromCartAsync(int productId, int productTypeId);
    Task UpdateQuantityAsync(CartProductResponse product);
    Task StoreCartItemsAsync(bool emptyLocalCart);
    Task GetCartItemsCountAsync();
}