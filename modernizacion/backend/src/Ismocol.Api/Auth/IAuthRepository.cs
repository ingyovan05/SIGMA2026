namespace Ismocol.Api.Auth;

public interface IAuthRepository
{
    Task<UserSession?> AuthenticateAsync(string encryptedUserName, string encryptedPassword, CancellationToken cancellationToken);
}
