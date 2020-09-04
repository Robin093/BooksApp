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
    public class IndexModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public IndexModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        public IList<Books> Books { get;set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books
                .Include(b => b.Genres).ToListAsync();
        }
    }
}
