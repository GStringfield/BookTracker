using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models
{
    public class BookDetail
    {
        public int BookID { get; set; }
        public int UserID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

    }
}
