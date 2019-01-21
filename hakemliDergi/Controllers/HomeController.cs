using prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace prj.Controllers
{
    public class HomeController : Controller
    {

        MagazineDb _dbMagazine = new MagazineDb();

        //jquery-ui autocomplete ozelligi kullaniliyor
        public ActionResult AutoComplete(string term)
        {
            var model = _dbMagazine.Magazines
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name //jquery-ui dokumantasyonunda bunun lavbel etiketi ile gelmesi gerektigi yaziyor.
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1) //?searchTerm = A
        {
            //Veri cogaltiginda search ve paging devreye girecek.
            var model = //_dbMagazine.Magazines.ToList();
                        //_dbMagazine.Magazines.OrderBy(r => r.Name);
                _dbMagazine.Magazines
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                //.Take(10) //Ilk 10 Restorani goster
                .Select(r => new MagazineListViewModel
                { Id = r.Id, Name = r.Name, Country = r.Country, CountOfReviews = r.Reviews.Count })
                .ToPagedList(page, 10);
            
            if(Request.IsAjaxRequest())
            {
                return PartialView("_Magazines", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_dbMagazine != null)
            {
                _dbMagazine.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}