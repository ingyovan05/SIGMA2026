using System.Text;

namespace Ismocol.Api.Auth;

/// <summary>
/// Compatibilidad temporal con FuncionesBase.Encryptar del sistema VB.NET.
/// Debe reemplazarse por hashes modernos cuando la base admita una migración de credenciales.
/// </summary>
public static class LegacyCredentialCipher
{
    public static string Encrypt(string value)
    {
        var input = value.Trim();
        var encrypted = new char[input.Length];

        for (var index = 0; index < input.Length; index++)
        {
            encrypted[index] = (char)(input[index] + index + 1 + input.Length);
        }

        Array.Reverse(encrypted);
        return new string(encrypted);
    }
}
