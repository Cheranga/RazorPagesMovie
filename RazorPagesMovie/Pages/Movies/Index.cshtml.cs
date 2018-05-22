using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        public string SearchString { get; set; }
        public IList<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string SelectedGenre { get; set; }

        public async Task OnGetAsync(string searchString, string selectedGenre, int? id)
        {
            SearchString = searchString;

            var genres = await GetGenres();
            var movies = await GetMovies(searchString, selectedGenre);

            var selectList = genres.Select(x => new {Value = x, Display = x}).ToList();
            selectList.Insert(0, new {Value = "", Display = "Select"});
            Genres = new SelectList(selectList, "Value", "Display", "");
            Movies = movies;
        }

        private Task<List<string>> GetGenres()
        {
            return _context.Movies.Select(x => x.Genre).Distinct().ToListAsync();
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