using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    // model class for BooksAuthors
    public class BooksAuthors
    {
        // identity field
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookAuthorid { get; set; }
        // Foreign key for Authors table
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }
        public Authors Authors { get; set; }
        // foreign key for Books table
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public Books Books { get; set; }
    }
}
