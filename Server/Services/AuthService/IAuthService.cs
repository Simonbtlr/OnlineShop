namespace OnlineShop.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> RegisterAsync(User user, string password);
    Task<bool> UserExistsAsync(string email);
}