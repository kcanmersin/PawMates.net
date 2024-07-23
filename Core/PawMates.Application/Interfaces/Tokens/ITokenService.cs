using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PawMates.Domain.Entities;

namespace PawMates.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
