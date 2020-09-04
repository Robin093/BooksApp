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
    public class DetailsModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DetailsModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

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
    }
}
