using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Contracts.ISQL
{
    public interface ISqlHelper
    {
        Task<int> ExecuteNonQueryAsync(string transactionSQL, List<SqlParameter> parameters);
        Task<DataTable> ExecuteReaderAsync(string transactionSQL, List<SqlParameter> parameters = null);
    }
}
