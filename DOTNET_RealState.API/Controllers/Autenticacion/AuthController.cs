using DOTNET_RealState.Infraestructura.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RealState.API.Controllers.Autenticacion
{
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (accessToken, refreshToken) = await _authService.LoginAsync(request.Username, request.Password);
            return Ok(new { accessToken, refreshToken });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            var newAccessToken = await _authService.RefreshAsync(request.RefreshToken);
            return Ok(new { accessToken = newAccessToken });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshRequest request)
        {
            await _authService.RevocarRefreshToken(request.RefreshToken);
            return Ok(new { mensaje = "Sesión cerrada" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RefreshRequest
    {
        public string RefreshToken { get; set; }
    }
}

