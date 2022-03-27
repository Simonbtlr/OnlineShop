using OnlineShop.Shared.Models;
using OnlineShop.Shared.Models.Shop;

namespace OnlineShop.Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategoriesAsync();
}