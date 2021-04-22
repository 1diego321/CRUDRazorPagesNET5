using CRUDRazorPages.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.IRepositories
{
    public interface IMovieRepository : IGenericRepository<MovieEntity>
    {
    }
}
