using BookTracker.Data;
using BookTracker.Models;
using BookTracker.Models.FutureReading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public class FutureReadingService
    {
        private readonly Guid _userID;

        public FutureReadingService(Guid userID)
        {
            _userID = userID;
        }

        public bool FutureReadingCreate(FutureReadingCreate model)
        {
            var entity =
                new FutureReading()
                {
                    FutureReadingID = model.FutureReadingID,
                    UserID = _userID,
                    BookID = model.BookID,
                    Title = model.Title,
                    Author = model.Author,
                    Notes = model.Notes,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FutureReading.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<FutureReadingListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .BookInventory
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new FutureReadingListItem
                                {
                                    FutureReadingID = e.FutureReadingID,
                                    BookID = e.BookID,
                                    Title = e.Book.Title,
                                    Author = e.Book.Author,
                                    Notes = e.Notes,
                                }

                        );
                return query.ToArray();
            }
}

        //left out Details for now
        public bool UpdateInventoryBook(BookInventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
             ctx
                 .BookInventory
                 .Single(e => e.FutureReadingID == model.FutureReadingID && e.UserID == _userID);

                entity.FutureReadingID = model.FutureReadingID;
                entity.BookID = model.BookID;
                entity.UserID = _userID;  
                entity.Notes = model.Notes;
             
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFutureBook(int futureReadingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
            ctx
                .BookInventory
                .Single(e => e.FutureReadingID == futureReadingID && e.UserID == _userID);

                ctx.BookInventory.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
