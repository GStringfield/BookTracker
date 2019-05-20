using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

namespace BookTracker.Models
{
    public class BookInventoryCreate
    {

        public int BookInventoryID { get; set; }
        public Guid UserID { get; set; }
        public int BookID { get; set; }

        public bool HasRead { get; set; }

        [Display(Name = "The type of Book owned")]
        public BookType TypeOfBook { get; set; }

       // [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Notes { get; set; }
    }
}
