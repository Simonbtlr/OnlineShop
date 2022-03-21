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

    public async Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText)
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(x => x.Title.ToLower().Contains(searchText.ToLower()) || 
                                   x.Description.ToLower().Contains(searchText.ToLower()))
                .Include(x => x.Variants)
                .ToListAsync()
        };

        return response;
    }
}