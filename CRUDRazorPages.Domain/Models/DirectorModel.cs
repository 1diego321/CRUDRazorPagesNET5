using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDRazorPages.Domain.Models
{
    public class DirectorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountOfPrizes { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
