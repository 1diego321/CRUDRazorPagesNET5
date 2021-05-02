using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Models.Movie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Services.IServices
{
    public interface IMovieService : IGenericService<Movie>
    {
        Task<MovieDetailsViewModel> GetForDetailsById(int id);
    }
}
