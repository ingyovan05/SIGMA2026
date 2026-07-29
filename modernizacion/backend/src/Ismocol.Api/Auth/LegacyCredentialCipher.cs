using Microsoft.VisualBasic;
using System.Text;

namespace Ismocol.Api.Auth;

/// <summary>
/// Compatibilidad temporal con FuncionesBase.Encryptar del sistema VB.NET.
/// Debe reemplazarse por hashes modernos cuando la base admita una migración de credenciales.
/// </summary>
public static class LegacyCredentialCipher
{
    static LegacyCredentialCipher()
    {
        // Chr/Asc del runtime de Visual Basic dependen de la página ANSI.
        // .NET moderno no la habilita de forma predeterminada.
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public static string Encrypt(string value)
    {
        var input = value.Trim();
        var encrypted = new char[input.Length];

        for (var index = 0; index < input.Length; index++)
        {
            // VB.NET Chr/Asc usa la página ANSI del sistema para los valores
            // entre 128 y 255. Un cast directo a char produce Unicode distinto.
            encrypted[index] = Strings.Chr(
                Strings.Asc(input[index]) + index + 1 + input.Length);
        }

        Array.Reverse(encrypted);
        return new string(encrypted);
    }
}
