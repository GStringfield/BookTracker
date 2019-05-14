using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Data
{
    public class BookInventory
    {
        public enum BookType
        {
            TraditionalBook = 1,
            eBook,
            AudioBook
        }

        //key for THIS table
        [Key]
        public int BookInventoryID { get; set; }

        //this is my foriegn key need this on models as well
        public int BookID { get; set; }

        public Guid UserID { get; set; }

        public bool IsOwned { get; set; }

        public bool HasRead { get; set; }

        //this is my navigation propery
        public virtual Book Book
        { get; set; }

        public string Notes { get; set; }

        public BookType  TypeofBook { get; set; }

    }
}
    
