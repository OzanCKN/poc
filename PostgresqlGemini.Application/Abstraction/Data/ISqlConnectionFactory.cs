using System.Data;

namespace PostgresqlGemini.Application.Abstraction.Data;

//Dapper ile denenecek.
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}