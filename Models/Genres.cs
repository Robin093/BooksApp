using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    // model class for Genres
    public class Genres
    {
        // constructor for class Genres
        public Genres()
        {
            Books = new List<Books>();
        }
        // identity field for table Genres
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        // name of genre
        public string Genre { get; set; }
        // used for foreign relationship with table Books
        public List<Books> Books { get; set; }
       
    }
}
