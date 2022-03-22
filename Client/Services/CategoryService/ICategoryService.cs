using OnlineShop.Shared.Models;

namespace OnlineShop.Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategoriesAsync();
}