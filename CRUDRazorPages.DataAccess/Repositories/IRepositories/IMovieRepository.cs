using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories.IRepositories
{
    public interface IMovieRepository : IGenericRepository<MovieEntity>
    {
    }
}
