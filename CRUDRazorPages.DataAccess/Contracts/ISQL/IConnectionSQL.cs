using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Contracts.ISQL
{
    public interface IConnectionSQL
    {
        SqlConnection GetConnection();
    }
}
