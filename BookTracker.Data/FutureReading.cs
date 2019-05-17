using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Data
{
   public  class FutureReading
    {
        [Key]
        public int FutureReadingID { get; set; }
        //foriegn key
        public int BookID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        //this is my navigation propery
        public virtual Book Book
        { get; set; }

    }
}
