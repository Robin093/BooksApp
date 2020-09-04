using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    // Books model class
    public class Books
    {
        // Constructor for Books class
        public Books()
        {
            BooksAuthors = new List<BooksAuthors>();
        }
     // setting this property as identity for table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        // book title
        public string Title { get; set; }
        // published date and time
        public DateTime PublishDate { get; set; }
        // review date time
        public DateTime ReviewDate { get; set; }
        // checkbox for if book is famous
        public bool IsFamous { get; set; }
        // store book review
        public string Review { get; set; }
        // foreign key for book genre
        [ForeignKey("Genres")]
        public int GenreId { get; set; }
        public Genres Genres { get; set; }
        // used for foreign relationship in table BooksAuthors
        public List<BooksAuthors> BooksAuthors { get; set; }

    }
}
