namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet] 
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return Ok(result);
    }
}