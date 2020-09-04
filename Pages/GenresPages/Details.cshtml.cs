using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.GenresPages
{
    public class DetailsModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DetailsModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        public Genres Genres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genres = await _context.Genres.FirstOrDefaultAsync(m => m.GenreId == id);

            if (Genres == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
