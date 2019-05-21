using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models.FutureReading
{
    public class FutureReadingEdit
    {
        public int FutureReadingID { get; set; }

        public int BookID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Notes { get; set; }
    }
}
