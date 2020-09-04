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

namespace BooksApp.Pages.BooksAuthorsPages
{
    public class EditModel : PageModel
    {
        private readonly BooksApp.Data.BooksAppContext _context;

        public EditModel(BooksApp.Data.BooksAppContext context)
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
           ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
           ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
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

            _context.Attach(BooksAuthors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksAuthorsExists(BooksAuthors.BookAuthorid))
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

        private bool BooksAuthorsExists(int id)
        {
            return _context.BooksAuthors.Any(e => e.BookAuthorid == id);
        }
    }
}
