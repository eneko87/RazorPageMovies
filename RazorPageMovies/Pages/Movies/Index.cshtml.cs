using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Models;

namespace RazorPageMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovies.Models.RazorPageMoviesContext _context;

        public IndexModel(RazorPageMovies.Models.RazorPageMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]        public string SearchString { get; set; }
        public SelectList Genero { get; set; } //Requiere using: Microsoft.AspNetCore.Mvc.Rendering; 

        [BindProperty(SupportsGet = true)]        public string MovieGenero { get; set; }


        public async Task OnGetAsync()
        {
            //La primera línea del método OnGetAsync crea una consulta LINQ para seleccionar las películas
            var movies = from m in _context.Movie                         select m;
            ////Si la propiedad SearchString no es NULL ni está vacía, 
            ////la consulta de películas se modifica para filtrar según la cadena de búsqueda:
            if (!string.IsNullOrEmpty(SearchString))            {
                //    /*El código s => s.Title.Contains() es una expresión lambda. 
                //     * Las lambdas se usan en consultas LINQ basadas en métodos como argumentos
                //     * para métodos de operador de consulta estándar,
                //     * como el método Where o Contains (usado en el código anterior).*/
                movies = movies.Where(s => s.Title.Contains(SearchString));            }

            IQueryable<string> generoQuery = from m in _context.Movie
                                             orderby m.Genre
                                             select m.Genre;

            if (!string.IsNullOrEmpty(MovieGenero))            {
                movies = movies.Where(x => x.Genre == MovieGenero);
            }



            Movie = await movies.ToListAsync();
            // Movie = await _context.Movie.ToListAsync();
        }
    }
}
