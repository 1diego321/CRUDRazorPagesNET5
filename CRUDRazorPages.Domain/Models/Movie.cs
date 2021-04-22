using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Models
{
    public class Movie
    {
        #region PROPERTIES
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Premiere { get; set; }
        public int Takings { get; set; }
        public int DirectorId { get; set; }
        #endregion
    }
}
