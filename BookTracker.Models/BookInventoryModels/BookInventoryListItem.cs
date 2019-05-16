using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

namespace BookTracker.Models
{
    public class BookInventoryListItem
    {
        [Key]
        public int BookInventoryID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool HasRead { get; set; }

        public BookType TypeOfBook { get; set; }


        public string Notes { get; set; }
    }
}
