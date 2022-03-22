using OnlineShop.Shared.DTO;
using OnlineShop.Shared.Models;

namespace OnlineShop.Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
    Task<ServiceResponse<ProductSearchResult>> SearchProductsAsync(string searchText, int page);
    Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
    Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync();
}