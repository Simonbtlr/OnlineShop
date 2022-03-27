using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace OnlineShop.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
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
        var response = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

        if (user is null)
        {
            response.Success = false;
            response.Message = "Пользователь не найден";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Неверный пароль";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> ChangePasswordAsync(int userId, string password)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user is null)
            return new ServiceResponse<bool>
            {
                Success = false, 
                Message = "Пользователь не найден"
            };
        
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _context.SaveChangesAsync();

        return new ServiceResponse<bool>
        {
            Data = true, 
            Message = "Пароль был изменен."
        };
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Email)
        };
        var key =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
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