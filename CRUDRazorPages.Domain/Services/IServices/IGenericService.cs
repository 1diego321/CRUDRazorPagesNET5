using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services.IServices
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T model);
        Task<int> Update(T model);
        Task<int> Delete(int id);
    }
}