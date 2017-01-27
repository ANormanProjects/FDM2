using ASP.NET.Advancedv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.Advancedv2.Controllers
{
    public class BooksController : Controller
    {

        BookDbContext db = new BookDbContext();
        // GET: Books
        public ActionResult Index()
        {
            return View("Index", db.books.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.books.Add(book);
            db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Success");
            }

            return RedirectToAction("Index");
        }
    }
}