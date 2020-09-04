using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.GenresPages
{
    public class CreateModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public CreateModel(BooksApp.Data.BooksAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Genres Genres { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Genres.Add(Genres);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
