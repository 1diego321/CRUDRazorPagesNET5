using CRUDRazorPages.DataAccess.Entities;
using CRUDRazorPages.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.DataAccess.Repositories.IRepositories
{
    public interface IDirectorRepository : IGenericRepository<DirectorEntity>
    {
        Task<List<DirectorEntity>> GetForDDL();
    }
}
