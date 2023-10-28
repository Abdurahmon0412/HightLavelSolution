using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Domain.Entities;

namespace N64Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {
        var result = await _accountService.VerificateAsyncs(token);

        return Ok(result);
    }

    [HttpPost("user")]
    public async ValueTask<IActionResult> CreateUser([FromBody] User user)
    {
        var token = await _accountService.CreateUserAsync(user);

        return Ok(token);
    }
}
