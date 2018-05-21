using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public string SearchString { get; set; }
        public IList<Movie> Movies { get;set; }
        public SelectList Genres { get; set; }
        public string SelectedGenre { get; set; }

        public async Task OnGetAsync(string searchString, string selectedGenre, int? id)
        {
            SearchString = searchString;

            var genres = await GetGenres();
            var movies = await GetMovies(searchString, selectedGenre);

            Genres = new SelectList(genres);
            Movies = movies;

        }

        private Task<List<string>> GetGenres()
        {
            return _context.Movies.Select(x => x.Genre).ToListAsync();
        }

        private Task<List<Movie>> GetMovies(string search, string genre)
        {
            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(genre))
            {
                return Task.FromResult(_context.Movies.ToList());
            }

            if (string.IsNullOrEmpty(search))
            {
                return _context.Movies.Where(x => x.Genre == genre).ToListAsync();
            }

            if (string.IsNullOrEmpty(genre))
            {
                return _context.Movies.Where(x => x.Title.Contains(search)).ToListAsync();
            }

            return _context.Movies.Where(x => x.Title.Contains(search) && x.Genre == genre).ToListAsync();
        }
    }
}
