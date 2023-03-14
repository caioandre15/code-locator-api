using Locator.api.Auth;
using Locator.Business.Interface;
using Locator.Models.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Locator.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authService.ProcessingLogin(model);
            if (result.Token == null) return Unauthorized();
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.ProcessingRegister(model);

            if (result.Status == "Error") StatusCode(StatusCodes.Status500InternalServerError, result);

            if (result.Status == null) return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var result = await _authService.ProcessingRegisterAdmin(model);

            if (result.Status == "Error") StatusCode(StatusCodes.Status500InternalServerError, result);

            if (result.Status == null) return BadRequest();

            return Ok(result);
        }
    }
}
