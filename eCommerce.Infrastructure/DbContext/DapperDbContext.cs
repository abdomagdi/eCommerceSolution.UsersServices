using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            //POSTGRES_HOST=localhost
            // POSTGRES_PORT = 5432
// POSTGRES_DATABASE = eCommerceUsers
// POSTGRES_USER = postgres
// POSTGRES_PASSWORD = admin
            string ConnectionStringTemplate = _configuration.GetConnectionString("PostgreSqlConnection")!;
            string connectionString = ConnectionStringTemplate.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
                .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT"))
                .Replace("$POSTGRES_DATABASE", Environment.GetEnvironmentVariable("POSTGRES_DATABASE"))
                .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"))
                .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _dbConnection;

       
    }
}
