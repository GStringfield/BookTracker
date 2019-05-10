using BookTracker.Models;
using BookTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookTracker.WebMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        [Authorize]
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userID);
            var model = service.GetBooks();

            return View(model);
        }
        //get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateBookService();


            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your Book was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Book could not be added.");

            return View(model);


        }

        private BookService CreateBookService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userID);
            return service;
        }

        public ActionResult Details(int bookID)
        {
            var svc = CreateBookService();
            var model = svc.GetBookByID(bookID);

            return View(model);
        }

        public ActionResult Edit(int bookID)
        {
            var service = CreateBookService();
            var detail = service.GetBookByID(bookID);
            var model =
                new BookEdit
                {
                    BookID = detail.BookID,
                    Title = detail.Title,
                    Author = detail.Author
                };
            return View(model);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int bookID, BookEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.BookID != bookID)
                
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }

        //    var service = CreateBookService();

        //    if (service.UpdateBook(model))
        //    {
        //        TempData["SaveResult"] = "Your book was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your book could not be updated.");
        //    return View(model);

        //}


    }
}