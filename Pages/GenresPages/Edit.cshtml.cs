using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.GenresPages
{
    public class EditModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public EditModel(BooksApp.Data.BooksAppContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Genres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenresExists(Genres.GenreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GenresExists(int id)
        {
            return _context.Genres.Any(e => e.GenreId == id);
        }
    }
}
