using OnlineShop.Shared.DTO;
using OnlineShop.Shared.DTO.Shop;
using OnlineShop.Shared.Models;
using OnlineShop.Shared.Models.Shop;

namespace OnlineShop.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    
    public ProductService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Include(x => x.Variants)
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        var product = await _context.Products
            .Include(x => x.Variants)
            .ThenInclude(x => x.ProductType)
            .FirstOrDefaultAsync(x => x.Id == productId);

        if (product == null)
        {
            response.Success = false;
            response.Message = "Продукт не найден.";
        }
        else
            response.Data = product;

        return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(x => x.Category.Url.ToLower().Equals(categoryUrl))
                .Include(x => x.Variants)
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<ProductSearchResult>> SearchProductsAsync(string searchText, int page)
    {
        var pageResults = 5f;
        var pageCount = Math.Ceiling((await FindProductsBySearchTextAsync(searchText)).Count / pageResults);
        var products = await _context.Products
            .Where(x => x.Title.ToLower().Contains(searchText.ToLower()) || 
                        x.Description.ToLower().Contains(searchText.ToLower()))
            .Include(x => x.Variants)
            .Skip((page - 1) * (int) pageResults)
            .Take((int) pageResults)
            .ToListAsync();
        
        var response = new ServiceResponse<ProductSearchResult>
        {
            Data = new ProductSearchResult
            {
                CurrentPage = page, 
                Pages = (int) pageCount, 
                Products = products
            }
        };

        return response;
    }
    
    public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText)
    {
        var products = await FindProductsBySearchTextAsync(searchText);
        var result = new List<string>();

        foreach (var product in products)
        {
            if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                result.Add(product.Title);
            
            if (product.Description is not null)
            {
                var punctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                var words = product.Description.Split().Select(x => x.Trim(punctuation));

                foreach (var word in words)
                {
                    if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                        result.Add(word);
                }
            }
        }

        return new ServiceResponse<List<string>> {Data = result};
    }

    public async Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(x => x.Featured)
                .Include(x => x.Variants)
                .ToListAsync()
        };

        return response;
    }

    private async Task<List<Product>> FindProductsBySearchTextAsync(string searchText)
    {
        return await _context.Products
            .Where(x => x.Title.ToLower().Contains(searchText.ToLower()) ||
                        x.Description.ToLower().Contains(searchText.ToLower()))
            .Include(x => x.Variants)
            .ToListAsync();
    }
}