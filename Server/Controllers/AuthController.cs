using System.Security.Claims;

namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> RegisterAsync(UserRegister request)
    {
        var response = await _authService.RegisterAsync(new User { Email = request.Email }, request.Password);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> LoginAsync(UserLogin request)
    {
        var response = await _authService.LoginAsync(request.Email, request.Password);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("change-password"), Authorize]
    public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string password)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _authService.ChangePasswordAsync(int.Parse(userId), password);

        if (!response.Success)
            BadRequest(response);
        
        return Ok(response);
    }
}