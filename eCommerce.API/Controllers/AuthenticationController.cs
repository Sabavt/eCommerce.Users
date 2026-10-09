using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.DTO;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthenticationController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var result = await _usersService.Register(registerRequest);

        if (result is not null || result?.Success is true)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var result = await _usersService.Login(loginRequest);

        if (result is not null || result?.Success is true)
        {
            return Ok(result);
        }

        return Unauthorized(result);
    }

    [HttpGet("[action]/{userID:guid}")]
    public async Task<IActionResult> GetUserByUserID(Guid userID)
    {
        var result = await _usersService.GetUserByUserID(userID);
        if (result is not null)
        {
            return Ok(result);
        }
        return NotFound(result);
    }
}