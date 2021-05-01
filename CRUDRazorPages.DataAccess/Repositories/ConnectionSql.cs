using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories
{
    public abstract class ConnectionSQL
    {
        private readonly IConfiguration _configuration;
        private const string _DefaultConnection = "DefaultConnection";

        public ConnectionSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString(_DefaultConnection).ToString());
        }
    }
}
