using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

namespace BookTracker.Models
{
    public class BookInventoryEdit
    {
        
        public int BookInventoryID { get; set; }

        //this is my foriegn key need this on models as well
        public int BookID { get; set; }

        public Guid UserID { get; set; }


        public string Title { get; set; }


        public string Author { get; set; }

        public bool HasRead { get; set; }

        public BookType TypeOfBook { get; set; }

        public string Notes { get; set; }
        public int FutureReadingID { get; set; }
    }
}
