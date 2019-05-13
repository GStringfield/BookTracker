using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public class BookOwnedService
    {
        private readonly Guid _userID;

        public BookOwnedService(Guid userID)
        {
            _userID = userID;
        }
        // this is a bool because return did it change the data context (save changes)
        public bool BookOwnedCreate(BookOwnedCreate model)
        {
            var content =
                new BookOwned()
                {
                    UserID = _userID,
                    BookID = model.BookID,
                    Title = model.Title,
                    Author = model.Author,

                };

            //TODO: apply boolean properties here

        }



    }
}
