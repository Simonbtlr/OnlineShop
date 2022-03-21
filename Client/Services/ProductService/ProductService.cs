namespace OnlineShop.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public event Action ProductsChanged;
    
    public List<Product> Products { get; set; } = new();

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        var result = categoryUrl == null 
            ? await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product")
            : await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>
                ($"api/Product/category/{categoryUrl}");

        if (result?.Data != null)
            Products = result.Data;
        
        ProductsChanged.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }
}