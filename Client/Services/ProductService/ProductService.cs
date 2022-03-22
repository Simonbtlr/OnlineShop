namespace OnlineShop.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action ProductsChanged;
    
    public List<Product> Products { get; set; } = new();

    public string Message { get; set; } = "Загрузка товаров...";

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
        
        ProductsChanged.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }

    public async Task SearchProductsAsync(string searchText)
    {
        var result =
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");

        if (result?.Data is not null)
            Products = result.Data;

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