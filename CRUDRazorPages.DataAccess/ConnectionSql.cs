using CRUDRazorPages.DataAccess.Contracts.ISQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess
{
    public abstract class ConnectionSQL : IConnectionSQL
    {
        private readonly IConfiguration _configuration;
        private const string _connectionStringName = "DefaultConnection";

        public ConnectionSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString(_connectionStringName));
        }
    }
}
