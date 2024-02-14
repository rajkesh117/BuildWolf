using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;

namespace BuildWolf.DAT.DBContext
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString = _configuration.GetConnectionString("SqlConnection");
            _connectionString = "Server=localhost;uid=root;pwd=Info@123;Database=buildwolf"; //jdbc: mysql://localhost:3306/?user=root
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
