using BookTracker.Data;
using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookTracker.Data.BookInventory;

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
                        .Books
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new BookInventoryListItem
                                {
                                  
                                    BookID = e.BookID,
                                    Title = e.Title,
                                    Author = e.Author,
                                   
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
                 .Books
                 .Single(e => e.BookID == bookInventoryID && e.UserID == _userID);
                return
                    new BookInventoryDetails
                    {
                       
                        BookID = entity.BookID,
                        Title = entity.Title,
                        Author = entity.Author
                       

                    };
            }



        }
        public bool UpdateBook(BookInventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
             ctx
                 .Books
                 .Single(e => e.BookID == model.BookID && e.UserID == _userID);

                entity.BookID = model.BookID;
                entity.Title = model.Title;
                entity.Author = model.Author;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteBook(int bookInventoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
            ctx
                .Books
                .Single(e => e.BookID == bookInventoryID && e.UserID == _userID);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
