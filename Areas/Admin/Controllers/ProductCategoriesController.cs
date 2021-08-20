using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodShopOnline.Models.EF;
using PagedList;

namespace FoodShopOnline.Areas.Admin.Controllers
{
    public class ProductCategoriesController : BaseController
    {
        private OnlineFoodShop db = new OnlineFoodShop();

        // GET: Admin/ProductCategories
        public ActionResult Index(string sortOrder , string searchString, string currentFilter, int? page)
        {
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            if(searchString !=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var productCategorys = db.ProductCategories.Select(pC => pC);

            if(!String.IsNullOrEmpty(searchString))
            {
                productCategorys = productCategorys.Where(pC => pC.Name.Contains(searchString));
            }

            if(sortOrder == "ten_desc")
            {
                productCategorys = productCategorys.OrderByDescending(pC => pC.Name);
            }
            else
            {
                productCategorys = productCategorys.OrderBy(pC => pC.Name);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(productCategorys.ToPagedList(pageNumber,pageSize));

        }

        // GET: Admin/ProductCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,ParentID,CreatedDate,CreateBy,ModifliedDate,ModifliedBy")] ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ProductCategories.Add(productCategory);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(productCategory);
            }

            
        }

        // GET: Admin/ProductCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,ParentID,CreatedDate,CreateBy,ModifliedDate,ModifliedBy")] ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(productCategory).State = EntityState.Modified;
                    db.SaveChanges();                    
                }
                return RedirectToAction("Index");
            }
            catch ( Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(productCategory);
            }
            
        }

        // GET: Admin/ProductCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(productCategory);
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
