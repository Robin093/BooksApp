using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.AuthorsPages
{
    public class DeleteModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DeleteModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Authors Authors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Authors = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);

            if (Authors == null)
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

            Authors = await _context.Authors.FindAsync(id);

            if (Authors != null)
            {
                _context.Authors.Remove(Authors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
