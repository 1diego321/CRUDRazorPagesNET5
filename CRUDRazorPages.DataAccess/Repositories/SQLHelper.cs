using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories
{
    public class SQLHelper : SQLConnection
    {
        public SQLHelper(IConfiguration configuration)
            : base(configuration)
        {

        }

        protected Task<int> ExecuteNonQuery(string transactSQL)
        {
            using (var connection = GetConnection())
            {
                
            }
    }
}
