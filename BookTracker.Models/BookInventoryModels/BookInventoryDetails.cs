using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models.BookInventoryModels
{
    class BookInventoryDetails
    {
        
        public int BookInventoryID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Notes")]
        public string Notes  { get; set; }


    }
}
