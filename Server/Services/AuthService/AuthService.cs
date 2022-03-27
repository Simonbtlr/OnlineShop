namespace OnlineShop.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<int>> RegisterAsync(User user, string password)
    {
        if (await UserExistsAsync(user.Email))
            return new ServiceResponse<int>
            {
                Success = false,
                Message = "Пользователь с таким email уже зарегистрирован."
            };
        
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new ServiceResponse<int> { Data = user.Id, Message = "Регистрация прошла успешно."};
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<ServiceResponse<string>> LoginAsync(string email, string password)
    {
        var response = new ServiceResponse<string>
        {
            Data = "token"
        };

        return response;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}