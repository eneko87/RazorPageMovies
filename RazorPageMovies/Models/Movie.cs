using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovies.Models
{
    public class Movie
    {
        public int ID { get; set; } // tipo publico, tipo dato, Identificador, get y set permite acceder R/W
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set;  }
    }
}
