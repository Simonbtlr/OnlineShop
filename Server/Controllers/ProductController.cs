using Microsoft.AspNetCore.Mvc;
using OnlineShop.Server.Data;

namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataContext _context;
    
    public ProductController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        
        return Ok(products);
    }
}