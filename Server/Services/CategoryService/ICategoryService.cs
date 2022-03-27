using OnlineShop.Shared.DTO;
using OnlineShop.Shared.DTO.Shop;
using OnlineShop.Shared.Models;
using OnlineShop.Shared.Models.Shop;

namespace OnlineShop.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
}