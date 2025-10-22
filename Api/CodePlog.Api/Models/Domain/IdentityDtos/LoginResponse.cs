namespace CodePlog.Api.Models.Domain.IdentityDtos;

public class LoginResponse
{
    public string Token { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }

}
