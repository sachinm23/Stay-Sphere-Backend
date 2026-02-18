namespace StaySphere.API.Controllers
{   
    using Microsoft.AspNetCore.Mvc;
    using StaySphere.Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using StaySphere.Application.DTOs.Auth;
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            Console.WriteLine($"Attempting to register user: {registerDto.Name}, {registerDto.Email}");
            var userRole = Enum.Parse<StaySphere.Domain.Enums.UserRole>(registerDto.Role, true);
            await _authService.RegisterAsync(registerDto.Name, registerDto.Email, registerDto.Password, userRole);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto.Email, loginDto.Password);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.RefreshTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(result);
        }
    }
}