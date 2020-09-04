using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksApp.Data;
using BooksApp.Models;

namespace BooksApp.Pages.BooksAuthorsPages
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
        ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            return Page();
        }

        [BindProperty]
        public BooksAuthors BooksAuthors { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BooksAuthors.Add(BooksAuthors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
