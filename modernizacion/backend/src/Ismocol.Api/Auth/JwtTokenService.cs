using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Ismocol.Api.Auth;

public sealed class JwtTokenService(string signingKey, string issuer, string audience)
{
    public (string Token, DateTimeOffset ExpiresAt) Create(UserSession user, int expirationMinutes)
    {
        var expiresAt = DateTimeOffset.UtcNow.AddMinutes(expirationMinutes);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.PersonId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.FullName),
            new("user_type", user.UserTypeCode.ToString())
        };
        claims.AddRange(user.Permissions
            .Where(permission => permission.Granted)
            .Select(permission => new Claim("permission", permission.FunctionCode.ToString())));

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer, audience, claims, expires: expiresAt.UtcDateTime, signingCredentials: credentials);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }
}
