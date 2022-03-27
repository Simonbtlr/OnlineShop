namespace OnlineShop.Client.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> RegisterAsync(UserRegister request);
    Task<ServiceResponse<string>> LoginAsync(UserLogin request);
}