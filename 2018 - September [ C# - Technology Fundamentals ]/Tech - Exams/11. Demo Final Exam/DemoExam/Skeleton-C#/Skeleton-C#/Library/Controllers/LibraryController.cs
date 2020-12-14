using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        // READ

        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                List<Book> books = db.Books.ToList();
                return View(books);
            }
        }

        // CREATE

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // EDIT - UPDATE

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                Book book = db.Books.Find(id);
                return View(book);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Books.Update(book);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                Book book = db.Books.Find(id);
                return View(book);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}