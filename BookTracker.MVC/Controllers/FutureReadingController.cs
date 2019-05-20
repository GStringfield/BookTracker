using BookTracker.Models;
using BookTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookTracker.MVC.Controllers
{
    public class FutureReadingController : Controller
    {
        // GET: FutureReading
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
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userID);


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




        [ActionName("Delete")]
        public ActionResult Delete(int futureReadingID)
        {
            var svc = CreateBookService();
            var model = svc.GetBookByID(futureReadingID);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int futureReadingID)
        {
            var service = CreateBookService();
            service.DeleteBook(futureReadingID);
            TempData["SaveResult"] = "Your book was deleted";
            return RedirectToAction("Index");
        }
    }
}
    
