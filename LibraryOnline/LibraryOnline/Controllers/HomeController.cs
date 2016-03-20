using LibraryOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryOnline.Controllers
{
    public class HomeController : Controller
    {
        DataClassesLibrartDataContext context = new DataClassesLibrartDataContext();
        List<TableBooks> books;

        public ActionResult Index()
        {
            InitialData();

            var query = (from book in context.TableBooks
                         select new
                         {
                             ID = book.Id,
                             Author = book.Author,
                             Title = book.Title
                             //Info = book.Story,
                         }).ToList();
            return View(query);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                TableBooks book = context.TableBooks.Where(x => x.Id == id).Single<TableBooks>();
                context.TableBooks.DeleteOnSubmit(book);
                context.SubmitChanges();
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(TableBooks b)
        {
            try
            {
                TableBooks book = new TableBooks
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title
                };
                context.TableBooks.InsertOnSubmit(book);
                context.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(b);
            }
        }

        [HttpPost]
        public ActionResult Insert(List<string>Data)
        {
            TableBooks book = new TableBooks();
            try
            {
                int i = Convert.ToInt32(Data[0]);
                book = context.TableBooks.Where(x => x.Id == i).Single<TableBooks>();
                book.Id = i;
                book.Author = Data[1];
                book.Title = Data[2];
                context.SubmitChanges();
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        void InitialData()
        {
            books = context.TableBooks.ToList();
            books.Add(new TableBooks
            {
                Id = 1,
                Author = "Dostoevsky",
                Title = "Idiot"
            });
            books.Add(new TableBooks
            {
                Id = 2,
                Author = "Chehov",
                Title = "Palata #6"
            });
            books.Add(new TableBooks
            {
                Id = 3,
                Author = "Gogol",
                Title = "Revisor"
            });
            try
            {
                foreach (TableBooks book in books)
                {
                    context.TableBooks.InsertOnSubmit(book);
                }
            }
            catch
            {

            }
            context.SubmitChanges();
        }
    }
}