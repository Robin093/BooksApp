using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    // authors model class
    public class Authors
    {
        // constructor for authors
        public Authors()
        {
            BooksAuthors = new List<BooksAuthors>();
    
        }
        // seting this property to table identity
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        // to store name of author
        public string AuthorName { get; set; }
        // to store bio for author
        public string AuthorBio { get; set; }
        // creating list for foreign key relationship in BooksAuthors Table
        public List<BooksAuthors> BooksAuthors { get; set; }
   
    }
}
