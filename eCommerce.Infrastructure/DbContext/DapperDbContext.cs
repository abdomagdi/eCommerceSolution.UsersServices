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
            string? ConnectionString = _configuration.GetConnectionString("PostgreSqlConnection");
            _dbConnection = new NpgsqlConnection(ConnectionString);
        }

        public IDbConnection DbConnection => _dbConnection;

       
    }
}
