using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.BooksPages
{
    public class DetailsModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DetailsModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        public Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books
                .Include(b => b.Genres).FirstOrDefaultAsync(m => m.BookId == id);

            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
