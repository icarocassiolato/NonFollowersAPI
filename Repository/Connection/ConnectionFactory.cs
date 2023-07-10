using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Repository.Contracts;
using System.Data;

namespace Repository.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection() 
            => new MySqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
    }
}
