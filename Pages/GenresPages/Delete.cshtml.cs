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
    public class DeleteModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DeleteModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genres = await _context.Genres.FindAsync(id);

            if (Genres != null)
            {
                _context.Genres.Remove(Genres);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
