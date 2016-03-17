using LibraryOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryOnline.Controllers
{
    public class HomeController : Controller
    {

        ModelLib context;
        List<Book> books;

        public ActionResult Index()
        {
            if(context == null)
            {
                InitialData();
            }

            var query = (from book in context.Books
                         select new
                         {
                             ID = book.ID,
                             Author = book.Author,
                             Title = book.Title
                             //Info = book.Story,
                         }).ToList();

            return View(query);
        }

        void InitialData()
        {
            context = new ModelLib();

            context.Books.RemoveRange(context.Books);
            context.SaveChanges();

            books = context.Books.ToList();
            books.Add(new Book
            {
                ID = 1,
                Author = "Dostoevsky",
                Title = "Idiot"
            });
            books.Add(new Book
            {
                ID = 2,
                Author = "Chehov",
                Title = "Palata #6"
            });
            books.Add(new Book
            {
                ID = 3,
                Author = "Gogol",
                Title = "Revisor"
            });
            foreach(Book book in books)
            {
                context.Books.Add(book);
            }
            context.SaveChanges();
        }
    }
}