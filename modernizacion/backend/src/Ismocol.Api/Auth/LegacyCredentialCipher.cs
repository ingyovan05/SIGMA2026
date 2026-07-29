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
        // La rutina original usa Len(Trim(Clave)) para el largo, pero Mid(Clave)
        // sobre el valor sin recortar. Conservamos deliberadamente ese matiz.
        var legacyLength = value.Trim().Length;
        var encrypted = new char[legacyLength];

        for (var index = 0; index < legacyLength; index++)
        {
            // VB.NET Chr/Asc usa la página ANSI del sistema para los valores
            // entre 128 y 255. Un cast directo a char produce Unicode distinto.
            encrypted[index] = Strings.Chr(
                Strings.Asc(value[index]) + index + 1 + legacyLength);
        }

        Array.Reverse(encrypted);
        return new string(encrypted);
    }
}
