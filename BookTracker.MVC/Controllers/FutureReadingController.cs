using BookTracker.Models;
using BookTracker.Models.FutureReading;
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
        // GET: BookInventory
        public ActionResult Index()
        {
            FutureReadingService service = CreateFutureReadingService();
            var model = service.GetBooks();

            return View(model);
        }
        //extracted from other methods to its own so can be used over and over
        private FutureReadingService CreateFutureReadingService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FutureReadingService(userID);
            return service;
        }

        //what the Hell
        private BookService CreateBookService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userID);
            return service;
        }

        //get
       
        public ActionResult Create()
        {
            var svc = CreateFutureReadingService();
            ViewBag.BookID = new SelectList(svc.GetBooks(), "BookID", "TitleAndAuthor");


            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //this all relates to the create MODEL
        public ActionResult Create(FutureReadingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFutureReadingService();

            //actually from service
            if (service.FutureReadingCreate(model))
            {
                TempData["SaveResult"] = "Your Book was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Book could not be added.");

            return View(model);

        }

        public ActionResult Details(int futureReadingID)
        {
            var svc = CreateFutureReadingService();
            var model = svc.GetBookByFutureReadingID(futureReadingID;

            return View(model);
        }

        public ActionResult Edit(int fututreReadingID)
        {
            var service = CreateFutureReadingService();
            var detail = service.GetBookByFutureReadingID(futureReadingID);
            var model =
                new FutureReadingEdit
                {
                   FutureReadingID = detail.FutureReadingID,
                    BookID = detail.BookID,
                    Title = detail.Title,
                    Author = detail.Author,
                    Notes = detail.Notes
                };
            return View(model);

        }
        public ActionResult Edit(int futureReadingID, FutureReadingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FutureReadingID != futureReadingID)

            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFutureReadingService();

            if (service.UpdateFutureReading(model))
            {
                TempData["SaveResult"] = "Your book was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your book could not be updated.");
            return View(model);

        }

        [ActionName("Delete")]
        public ActionResult Delete(int futureReadingID)
        {
            var svc = CreateFutureReadingService();
            var model = svc.GetBookByFutureReadingID(futureReadingID);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int futureReadingID)
        {
            var service = CreateFutureReadingService();
            service.DeleteFutureReadingBook(futureReadingID);
            TempData["SaveResult"] = "Your book was deleted";
            return RedirectToAction("Index");
        }
    }
}
    
