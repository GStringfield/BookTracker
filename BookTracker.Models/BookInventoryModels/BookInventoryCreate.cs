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
        

        public Guid UserID { get; set; }
        public int BookID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }


        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Author { get; set; }

     
        public bool HasRead { get; set; }

        [Display(Name = "The type of Book owned")]
        public BookType BookType { get; set; }

       // [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Notes { get; set; }
    }
}
