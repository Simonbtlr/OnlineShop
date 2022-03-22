namespace OnlineShop.Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    List<Product> Products { get; set; }
    string Message { get; set; }
    string LastSearchText { set; get; }
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    Task GetProductsAsync(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task<List<string>> GetProductSearchSuggestionsAsync(string searchText);
    Task SearchProductsAsync(string searchText, int page);
}