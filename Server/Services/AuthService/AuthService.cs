namespace OnlineShop.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }

    public Task<ServiceResponse<int>> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }
}