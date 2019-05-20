using BookTracker.Data;
using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public class BookInventoryService
    {
        private readonly Guid _userID;

        public BookInventoryService(Guid userID)
        {
            _userID = userID;
        }

        // this is a bool because return did it change the data context (save changes)
        public bool BookInventoryCreate(BookInventoryCreate model)
        {
            var content =
                new BookInventory()
                {
                    BookInventoryID = model.BookInventoryID,
                    UserID = _userID,
                    BookID = model.BookID,
                    HasRead = model.HasRead,
                    Notes = model.Notes,
                    TypeOfBook = model.TypeOfBook

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BookInventory.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookInventoryListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .BookInventory
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new BookInventoryListItem
                                {
                                    BookInventoryID = e.BookInventoryID,
                                    BookID = e.BookID,
                                    Title = e.Book.Title,
                                    Author = e.Book.Author,
                                    HasRead = e.HasRead,
                                    Notes = e.Notes,
                                    TypeOfBook = e.TypeOfBook,

                                }

                        );

                return query.ToArray();
            }
        }

        public BookInventoryDetails GetBookByInventoryID(int bookInventoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
             ctx
                 .BookInventory
                 .Single(e => e.BookInventoryID == bookInventoryID && e.UserID == _userID);
                return
                    new BookInventoryDetails
                    {
                        BookInventoryID = entity.BookInventoryID,
                        BookID = entity.BookID,
                        Title = entity.Book.Title,
                        Author = entity.Book.Author,
                        HasRead = entity.HasRead,
                        Notes = entity.Notes,
                        TypeOfBook = entity.TypeOfBook,

                    };
            }

        }

        public bool UpdateInventoryBook(BookInventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
             ctx
                 .BookInventory
                 .Single(e => e.BookInventoryID == model.BookInventoryID && e.UserID == _userID);

                entity.BookInventoryID = model.BookInventoryID;
                entity.UserID = _userID;
                entity.BookID = model.BookID;
                entity.HasRead = model.HasRead;
                entity.Notes = model.Notes;
                entity.TypeOfBook = model.TypeOfBook;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInventoryBook(int bookInventoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
            ctx
                .BookInventory
                .Single(e => e.BookInventoryID == bookInventoryID && e.UserID == _userID);

                ctx.BookInventory.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
