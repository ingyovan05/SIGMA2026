using Microsoft.Data.SqlClient;

namespace Ismocol.Api.Infrastructure;

public sealed class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
{
    public SqlConnection Create()
    {
        var connectionString = configuration.GetConnectionString("LegacySqlServer");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "No se configuró ConnectionStrings:LegacySqlServer. Use secretos de usuario o una variable de entorno.");
        }

        return new SqlConnection(connectionString);
    }
}
