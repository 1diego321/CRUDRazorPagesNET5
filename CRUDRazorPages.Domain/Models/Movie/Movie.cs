using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Models.Movie
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Duración")]
        public int Duration { get; set; }

        [Display(Name = "Fecha de Estreno")]
        public DateTime Premiere { get; set; }

        [Display(Name = "Recaudación")]
        public int Takings { get; set; }

        [Display(Name = "Director")]
        public int DirectorId { get; set; }
    }
}
