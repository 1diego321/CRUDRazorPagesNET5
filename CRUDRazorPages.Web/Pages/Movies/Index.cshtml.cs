using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDRazorPages.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDRazorPages.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Movie _model;

        public List<Movie> Movies { get; set; }

        public void OnGet()
        {
        }
    }
}
