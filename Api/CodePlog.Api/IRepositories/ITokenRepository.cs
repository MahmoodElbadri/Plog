using Microsoft.AspNetCore.Identity;

namespace CodePlog.Api.IRepositories;

public interface ITokenRepository
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
}
