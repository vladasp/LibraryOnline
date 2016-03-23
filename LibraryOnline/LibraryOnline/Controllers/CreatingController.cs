using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryOnline.Controllers
{
    public class CreatingController : Controller
    {
        DataClassesLibrartDataContext context = new DataClassesLibrartDataContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<string> Data)
        {
            TableBooks book = new TableBooks();
            try
            {
                int i = Convert.ToInt32(Data[0]);
                book.Id = i;
                book.Author = Data[1];
                book.Title = Data[2];
                context.TableBooks.InsertOnSubmit(book);
                context.SubmitChanges();
            }
            catch
            {
            }
            return RedirectToAction("Index", "Home", context);
        }
    }
}