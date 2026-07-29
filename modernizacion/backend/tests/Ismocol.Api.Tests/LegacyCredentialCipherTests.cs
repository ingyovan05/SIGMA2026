using Ismocol.Api.Auth;

namespace Ismocol.Api.Tests;

public sealed class LegacyCredentialCipherTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("a", "c")]
    [InlineData("abc", "ige")]
    [InlineData(" test ", "{lz%")]
    [InlineData("usuarioyas", "‡t‹€yo‚€")]
    public void Encrypt_MatchesLegacyVbAlgorithm(string value, string expected)
    {
        Assert.Equal(expected, LegacyCredentialCipher.Encrypt(value));
    }
}
