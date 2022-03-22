using OnlineShop.Shared.DTO;
using OnlineShop.Shared.Models;

namespace OnlineShop.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action ProductsChanged;
    
    public List<Product> Products { get; set; } = new();

    public string Message { get; set; } = "Загрузка товаров...";
    public string LastSearchText { get; set; } = string.Empty;

    public int CurrentPage { get; set; } = 1;
    public int PageCount { get; set; } = 0;

    public ProductService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        var result = categoryUrl == null 
            ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured")
            : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>
                ($"api/product/category/{categoryUrl}");

        if (result?.Data != null)
            Products = result.Data;

        CurrentPage = 1;
        PageCount = 0;

        if (Products.Count == 0)
            Message = "Товары не найдены.";
        
        ProductsChanged.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }

    public async Task SearchProductsAsync(string searchText, int page)
    {
        LastSearchText = searchText;
        var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>
                ($"api/product/search/{searchText}/{page}");

        if (result?.Data is not null)
        {
            Products = result.Data.Products;
            CurrentPage = result.Data.CurrentPage;
            PageCount = result.Data.Pages;
        }

        if (Products.Count == 0)
            Message = "Товары не найдены.";
        
        ProductsChanged.Invoke();
    }

    public async Task<List<string>> GetProductSearchSuggestionsAsync(string searchText)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>
                ($"api/product/searchsuggestions/{searchText}");

        return result.Data;
    }
}