using Microsoft.Data.SqlClient;

namespace Ismocol.Api.Infrastructure;

public interface ISqlConnectionFactory
{
    SqlConnection Create();
}
