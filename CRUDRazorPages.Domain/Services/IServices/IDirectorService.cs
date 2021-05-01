using CRUDRazorPages.Domain.Models.Director;
using CRUDRazorPages.Domain.Models.Director.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services.IServices
{
    public interface IDirectorService : IGenericService<Director>
    {
        Task<List<DirectorForDDLViewModel>> GetForDDL();
    }
}
