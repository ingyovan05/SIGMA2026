namespace Ismocol.Api.Auth;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
}

public sealed class AuthService(
    IAuthRepository repository,
    JwtTokenService tokenService,
    IConfiguration configuration) : IAuthService
{
    public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
        {
            return null;
        }

        var user = await repository.AuthenticateAsync(
            LegacyCredentialCipher.Encrypt(request.UserName),
            LegacyCredentialCipher.Encrypt(request.Password),
            cancellationToken);
        if (user is null)
        {
            return null;
        }

        var expirationMinutes = configuration.GetValue("Jwt:ExpirationMinutes", 480);
        var (token, expiresAt) = tokenService.Create(user, expirationMinutes);
        return new LoginResponse(token, expiresAt, user);
    }
}
