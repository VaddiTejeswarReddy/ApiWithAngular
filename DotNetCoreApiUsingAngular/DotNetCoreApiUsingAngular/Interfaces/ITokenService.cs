using DotNetCoreApiUsingAngular.Models;

namespace DotNetCoreApiUsingAngular.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
