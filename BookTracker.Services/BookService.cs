using BookTracker.Data;
using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public class BookService
    {
        private readonly Guid _userID;

        public BookService(Guid userID)
        {
            _userID = userID;
        }


        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    UserID = _userID,
                    BookID = model.BookID,
                    Title = model.Title,
                    Author = model.Author,
                  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                                     ctx
                                         .Books
                                         //TODO: apply boolean properties here
                                         .Where(e => e.UserID == _userID)
                                         .Select(
                                             e =>
                                                 new BookListItem
                                                 {
                                                    
                                                     BookID = e.BookID,
                                                     Title = e.Title,
                                                     Author = e.Author
                                                    

                                                 }
                                                  );
                return query.ToArray();

            }

        }

        public BookDetail GetBookByID(int bookID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
             ctx
                 .Books
                 .Single(e => e.BookID == bookID && e.UserID == _userID);
                return
                    new BookDetail
                    {
                        BookID = entity.BookID,
                        Title = entity.Title,
                        Author = entity.Author

                    };
            }



        }

        public bool UpdateBook(BookEdit model)
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

        public bool DeleteBook(int bookID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
            ctx
                .Books
                .Single(e => e.BookID == bookID && e.UserID == _userID);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
