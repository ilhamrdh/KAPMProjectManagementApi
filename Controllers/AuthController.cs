using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAPMProjectManagementApi.Dto.Auth;
using KAPMProjectManagementApi.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace KAPMProjectManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth/login")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);

            return Ok(response);

        }
    }
}