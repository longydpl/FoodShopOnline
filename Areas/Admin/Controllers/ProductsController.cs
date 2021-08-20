
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
    public class ProductsController : BaseController
    {
        private OnlineFoodShop db = new OnlineFoodShop();

        // GET: Admin/Products
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
            var products = db.Products.Select(p => p);
            if(searchString!=null)
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }
            if(sortOrder == "ten_desc")
            {
                products = products.OrderByDescending(p => p.Name);
            }
            else
            {
                products = products.OrderBy(p => p.Name);
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,Price,PromotionPrice,Quantity,CategoryID,Detail,CreatedDate,CreateBy,ModifliedDate,ModifliedBy,MetaKeywords,MetaDescription,Status,CountView,Tags")] Product product)
        {
            try
            {
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if(f != null && f.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    string uploadPath = Server.MapPath("~/Asset/img/" + fileName);
                    f.SaveAs(uploadPath);
                    product.Image = fileName;
                }
                product.CreatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();         
                }

                ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(product);
            }
            
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,Price,PromotionPrice,Quantity,CategoryID,Detail,CreatedDate,CreateBy,ModifliedDate,ModifliedBy,MetaKeywords,MetaDescription,Status,CountView,Tags")] Product product)
        {
            try
            {
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if(f!=null && f.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    string uploadPath = Server.MapPath("~/Asset/img/" + fileName);
                    f.SaveAs(uploadPath);
                    product.Image = fileName;
                }
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();                    
                }
                ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(product);
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
