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
}