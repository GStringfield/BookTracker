using BookTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models
{
    public class FutureReadingCreate
    {
        [Key]
        public int FutureReadingID { get; set; }
        public Guid UserID { get; set; }
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Notes { get; set; }

        //this is my navigation propery
        public virtual Book Book
        { get; set; }

    }
}
