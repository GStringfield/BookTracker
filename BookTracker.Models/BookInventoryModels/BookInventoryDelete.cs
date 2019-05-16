using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

namespace BookTracker.Models
{
     public class BookInventoryDelete
    {
        public int BookInventoryID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        public bool HasRead { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public BookType TypeOfBook { get; set; }
    }
}
