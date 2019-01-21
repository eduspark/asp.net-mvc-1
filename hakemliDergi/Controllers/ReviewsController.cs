using prj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prj.Controllers
{
    public class ReviewsController : Controller
    {
        MagazineDb _db = new MagazineDb();
        // GET: Reviews
        public ActionResult Index([Bind(Prefix="id")]int magazineId)
        {
            var magazine = _db.Magazines.Find(magazineId);
            if(magazine != null)
            {
                return View(magazine);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int magazineId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(MagazineReview review)
        {
            if (ModelState.IsValid) //False ise model binding de sorun var demektir.
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.MagazineId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.Find(id);
            return View(review);           
            
        }


        [HttpPost]
        //public ActionResult Edit([Bind(Exclude = "ReviewerName")]MagazineReview review)
        public ActionResult Edit(MagazineReview review)
        {
            if (ModelState.IsValid) //False ise model binding de sorun var demektir.
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges(); //State Modified ise veri tabanina isler
                return RedirectToAction("Index", new { id = review.MagazineId });
            }
            return View(review);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
