using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models
{
    public class BookCreate
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

       
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Author { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
