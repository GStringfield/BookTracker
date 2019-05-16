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
    public class BookInventoryController : Controller
    {
        // GET: BookInventory
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
        public ActionResult Create(BookInventoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateInventoryService();


            if (service.BookInventoryCreate(model))
            {
                TempData["SaveResult"] = "Your Book was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Book could not be added.");

            return View(model);

        }
        private BookInventoryService CreateInventoryService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var services = new BookInventoryService(userID);
            return services;
        }
        public ActionResult Details(int bookInventoryID)
        {
            var svc = CreateInventoryService();
            var model = svc.GetBookByInventoryID(bookInventoryID);

            return View(model);
        }

        public ActionResult Edit(int bookInventoryID)
        {
            var service = CreateInventoryService();
            var detail = service.GetBookByInventoryID(bookInventoryID);
            var model =
                new BookInventoryEdit
                {
                    BookInventoryID = detail.BookInventoryID,
                    BookID = detail.BookID,
                    Title = detail.Title,
                    Author = detail.Author,
                    HasRead = detail.HasRead,
                    TypeOfBook = detail.TypeOfBook,
                    Notes = detail.Notes
                };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int bookInventoryID, BookInventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BookInventoryID != bookInventoryID)

            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.UpdateBook(model))
            {
                TempData["SaveResult"] = "Your book was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your book could not be updated.");
            return View(model);

        }

        [ActionName("Delete")]
        public ActionResult Delete(int bookInventoryID)
        {
            var svc = CreateInventoryService();
            var model = svc.GetBookByInventoryID(bookInventoryID);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int bookInventoryID)
        {
            var service = CreateInventoryService();
            service.DeleteBook(bookInventoryID);
            TempData["SaveResult"] = "Your book was deleted";
            return RedirectToAction("Index");
        }
    }
}
