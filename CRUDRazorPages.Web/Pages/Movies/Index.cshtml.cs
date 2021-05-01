using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDRazorPages.Domain.Models.Movie;
using CRUDRazorPages.Domain.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDRazorPages.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _service;

        public IndexModel(IMovieService service)
        {
            _service = service;
        }

        public List<Movie> Movies { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            try
            {
                Movies = await _service.GetAll();
            }
            catch (Exception ex)
            {
                //I will do something with the exception later
            }
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            try
            {
                var oMovie = await _service.GetById(id);

                if (oMovie == null) 
                    return NotFound(new { Message = "Error: Recurso no encontrado o no existe." });

                await _service.Delete(id);

                Message = "Se eliminó la pelicula correctamente";

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                return Redirect("~/Error");
            }
        }
    }
}
