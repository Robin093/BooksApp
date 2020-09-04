using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksApp.Models;

namespace BooksApp.Data
{
    public class BooksAppContext : DbContext
    {
        public BooksAppContext (DbContextOptions<BooksAppContext> options)
            : base(options)
        {
        }

        // DbSet for Books Table
        public DbSet<BooksApp.Models.Books> Books { get; set; }
        // DbSet for Genre Table
        public DbSet<BooksApp.Models.Genres> Genres { get; set; }
        // DbSet for Authors Table
        public DbSet<BooksApp.Models.Authors> Authors { get; set; }
        // DbSet for BooksAuthors Table
        public DbSet<BooksApp.Models.BooksAuthors> BooksAuthors { get; set; }
    }
}
