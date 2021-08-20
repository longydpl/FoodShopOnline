 using FoodShopOnline.Common;
using FoodShopOnline.Models.Dao;
using FoodShopOnline.Models.EF;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FoodShopOnline.Areas.Admin.Controllers
{
    public class AdminsController : BaseController
    {
        private OnlineFoodShop db = new OnlineFoodShop();

        // GET: Admin/Admins
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var admins = db.Admins.Select(p => p);
            if (!String.IsNullOrEmpty(searchString))
            {
                admins = admins.Where(p => p.Username.Contains(searchString));
            }
            if (sortOrder == "ten_desc")
            {
                admins = admins.OrderByDescending(p => p.Username);
            }
            else
            {
                admins = admins.OrderBy(p => p.Username);
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(admins.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Admins/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = db.Admins.Find(id);
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // GET: Admin/Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,Password,Type,Status")] Admins admins)
        {
            try
            {
                var dao = new AdminDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(admins.Password);
                admins.Password = encryptedMd5Pas;
                if (ModelState.IsValid)
                {
                    db.Admins.Add(admins);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(admins);
            }


        }

        // GET: Admin/Admins/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = db.Admins.Find(id);
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // POST: Admin/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Username,Password,Type,Status")] Admins admins)
        {
            try
            {
                var dao = new AdminDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(admins.Password);
                admins.Password = encryptedMd5Pas;
                if (ModelState.IsValid)
                {
                    db.Entry(admins).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(admins);
            }

        }

        // GET: Admin/Admins/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admins admins = db.Admins.Find(id);
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        // POST: Admin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Admins admins = db.Admins.Find(id);
            db.Admins.Remove(admins);
            db.SaveChanges();
            return RedirectToAction("Index");
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
