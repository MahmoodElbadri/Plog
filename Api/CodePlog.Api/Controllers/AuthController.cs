using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain.IdentityDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodePlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<IdentityUser> _userManager,
    ITokenRepository _tokenRepository) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterAddRequest registerRequest)
    {
        var user = new IdentityUser
        {
            UserName = registerRequest.Email.Trim(),
            Email = registerRequest.Email.Trim(),
        };
        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(user, "Reader");
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem(ModelState);
            }
        }
        else
        {
            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                
            }
            return ValidationProblem(ModelState);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginAddRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email.Trim());
        if(user is not null)
        {
            var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password.Trim());
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token =  _tokenRepository.CreateJwtToken(user, roles.ToList());
                var loginResponse = new LoginResponse
                {
                    Email = user.Email,
                    Roles = roles.ToList(),
                    Token = token,
                };
                return Ok(loginResponse);
            }
        }
        ModelState.AddModelError("email", "Invalid email or password.");
        return ValidationProblem(ModelState);
    }
}
