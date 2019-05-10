using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Data
{
     public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        public Guid UserID { get; set; }
   
        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

    }
}
