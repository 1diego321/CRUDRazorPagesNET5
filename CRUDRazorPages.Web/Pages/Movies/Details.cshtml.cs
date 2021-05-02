using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Models.Movie.ViewModel;
using CRUDRazorPages.Domain.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDRazorPages.Web.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        #region DEPENDENCIES
        private readonly IMovieService _movieService;
        #endregion

        #region CONSTRUCTOR
        public DetailsModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        #endregion

        #region PROPERTIES
        [BindProperty]
        public MovieDetailsViewModel Movie { get; set; }
        #endregion

        #region METHODS
        public async Task OnGet(int id)
        {
            Movie = await _movieService.GetForDetailsById(id);
        }
        #endregion
    }
}
