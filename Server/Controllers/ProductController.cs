using OnlineShop.Shared.DTO;
using OnlineShop.Shared.DTO.Shop;
using OnlineShop.Shared.Models;
using OnlineShop.Shared.Models.Shop;

namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync()
    {
        var result = await _productService.GetProductsAsync();
        return Ok(result);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int productId)
    {
        var result = await _productService.GetProductAsync(productId);
        return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByCategoryAsync(string categoryUrl)
    {
        var result = await _productService.GetProductsByCategoryAsync(categoryUrl);
        return Ok(result);
    }

    [HttpGet("search/{searchText}/{page}")]
    public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProductsAsync(string searchText, int page = 1)
    {
        var result = await _productService.SearchProductsAsync(searchText, page);
        return Ok(result); 
    }

    [HttpGet("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestionsAsync(string searchText)
    {
        var result = await _productService.GetProductSearchSuggestionsAsync(searchText);
        return Ok(result); 
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProductsAsync()
    {
        var result = await _productService.GetFeaturedProductsAsync();
        return Ok(result); 
    }
}