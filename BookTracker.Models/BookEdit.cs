using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

namespace BookTracker.Models
{
    public class BookEdit
    {
      
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
                  
    }
}
