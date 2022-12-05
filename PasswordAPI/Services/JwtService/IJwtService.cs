using Microsoft.AspNetCore.Identity;
using PasswordAPI.Models;

namespace PasswordAPI.Services.JwtService
{
    public interface IJwtService
    {
        AuthenticationResponse CreateToken(IdentityUser user);

    }
}
