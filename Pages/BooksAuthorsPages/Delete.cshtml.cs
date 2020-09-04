using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.BooksAuthorsPages
{
    public class DeleteModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DeleteModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BooksAuthors BooksAuthors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BooksAuthors = await _context.BooksAuthors
                .Include(b => b.Authors)
                .Include(b => b.Books).FirstOrDefaultAsync(m => m.BookAuthorid == id);

            if (BooksAuthors == null)
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

            BooksAuthors = await _context.BooksAuthors.FindAsync(id);

            if (BooksAuthors != null)
            {
                _context.BooksAuthors.Remove(BooksAuthors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
