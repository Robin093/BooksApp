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
    public class DetailsModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public DetailsModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

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
    }
}
