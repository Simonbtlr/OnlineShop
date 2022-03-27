using OnlineShop.Shared.DTO;
using OnlineShop.Shared.DTO.Shop;
using OnlineShop.Shared.Models;
using OnlineShop.Shared.Models.Shop;

namespace OnlineShop.Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    public List<Category> Categories { get; set; } = new();
    
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetCategoriesAsync()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
        
        if (response?.Data != null)
            Categories = response.Data;
    }
}