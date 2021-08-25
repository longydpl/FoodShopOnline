using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FoodShopOnline.Models.Dao;

namespace FoodShopOnline.Controllers
{
    public class ProductController : Controller
    {

        private OnlineFoodShop db = new OnlineFoodShop();
        // GET: Product
        public ActionResult AllProduct(int? page)
        {
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Select(p => p);
            products = products.OrderBy(p => p.ID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            ViewBag.Start = pageNumber * 10 - 9;
            if (pageNumber*10 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 10;
            }
            return View(productsDao.GetProducts(pageNumber,pageSize));
        }


        public ActionResult NewProducts(int? page)
        {
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Select(p => p);
            products = products.OrderByDescending(p => p.CreatedDate).Take(25);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            ViewBag.Start = pageNumber * 10 - 9;
            if (pageNumber * 10 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 10;
            }
            return View(productsDao.GetNewProducts(pageNumber, pageSize));
        }


        public ActionResult SpecialProducts(int? page)
        {
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Select(p => p);
            products = products.OrderByDescending(p => p.CountView).Take(12);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            ViewBag.Start = pageNumber * 6 - 5;
            if (pageNumber * 6 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 6;
            }
            return View(productsDao.GetSpecialProducts(pageNumber, pageSize));
        }



        public ActionResult ListProductByCategoryID(string metatitle, int? page)
        {
            var model = db.ProductCategories.SingleOrDefault(x => x.MetaTitle == metatitle);
            ViewBag.CateDesc = model.Description;
            ViewBag.Name = model.Name;
            if (model.ID == 1)
            {
                FoodShopOnline.Models.Dao.ProductCategory productCategory = new Models.Dao.ProductCategory();
                ViewBag.List = productCategory.GetByParentID(1);
                return View("Index");
            }
            int countRecord = db.Products.Where(x => x.CategoryID == model.ID).Count();;

            ViewBag.Count = countRecord;
            ViewBag.Meta = metatitle;
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Where(p => p.CategoryID == model.ID);
            products = products.OrderBy(x => x.ID);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            ViewBag.Start = pageNumber * 5 - 4;
            if (pageNumber * 10 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 5;
            }
            return View(productsDao.GetProductsByCateID(model.ID, pageNumber, pageSize));

        }


        public ActionResult ProductDetail(string metatitle1)
        {
            var model = db.Products.SingleOrDefault(p => p.MetaTitle == metatitle1);
            if(model != null)
            {
                model.CountView += 1;
            }    
            db.SaveChanges();
            if (model == null)
            {
                return HttpNotFound();
            }
            int count = db.Products.Where(p => p.CategoryID == model.CategoryID && p.ID != model.ID).Count();
            if(count > 6)
            {
                ViewBag.Lst = db.Products.Where(p => p.CategoryID == model.CategoryID && p.ID != model.ID).Take(6).ToList();
            }
            else
            {
                ViewBag.Lst = db.Products.Where(p => p.CategoryID == model.CategoryID && p.ID != model.ID).ToList();
            }
            return View(model);
        }
    }
}