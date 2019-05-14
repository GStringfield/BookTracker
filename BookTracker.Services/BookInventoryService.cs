﻿using BookTracker.Data;
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
                    
                    UserID = _userID,
                    BookID = model.BookID,
                    TypeofBook = model.BookType

                };

            //TODO: apply boolean properties here
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BookInventory.Add(content);
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
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new BookListItem
                                {
                                    BookID = e.BookID,
                                    Title = e.Title,
                                }
                                    
                        );

                return query.ToArray();
            }
        }





    }
}