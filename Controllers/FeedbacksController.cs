using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodShopOnline.Models.EF;

namespace FoodShopOnline.Controllers
{
    public class FeedbacksController : Controller
    {
        private OnlineFoodShop db = new OnlineFoodShop();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Email,Phone,Content,CreatedDate,CreateBy,ModifliedDate,ModifliedBy")] Feedback feedback)
        {
            feedback.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        public ActionResult Map()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
