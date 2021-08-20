using FoodShopOnline.Models.Dao;
using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShopOnline.Controllers
{
    public class HomeController : Controller
    {
        private OnlineFoodShop db = new OnlineFoodShop();
        // GET: Home
        public ActionResult Index()
        {
            ProductsDao productsDao = new ProductsDao();
            ViewBag.ListTopProduct = productsDao.ListProduct(11);
            ViewBag.MonAnVat = productsDao.GetListProductById(2);
            ViewBag.MonChe = productsDao.GetListProductById(7);
            ViewBag.SuaChua = productsDao.GetListProductById(8);
            ViewBag.SinhTo = productsDao.GetListProductById(9);
            ViewBag.NuocEp = productsDao.GetListProductById(10);
            ViewBag.HoaQuaDam = productsDao.GetListProductById(11);
            ViewBag.HoaQuaTuoi = productsDao.GetListProductById(12);
            ViewBag.ThucPhamTuoiSong = productsDao.GetListProductById(13);
            return View();
        }


        public ActionResult ProductCategory()
        {
            FoodShopOnline.Models.Dao.ProductCategory productCategory = new Models.Dao.ProductCategory();
            var model = productCategory.GetByParentID(null);
            return PartialView(model);
        }

        public ActionResult ProductCategory1()
        {
            FoodShopOnline.Models.Dao.ProductCategory productCategory = new Models.Dao.ProductCategory();
            var model = productCategory.GetByParentID(1);
            return PartialView(model);
        }

        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }



        public ActionResult Search(string keyword, int? page)
        {
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Where(p => p.Name.Contains(keyword));
            products = products.OrderBy(p => p.ID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            if(products.Count() < 10)
            {
                ViewBag.Start = pageNumber * 10 - 9;
                ViewBag.End = products.Count();
                return View(productsDao.GetSearchProducts(pageNumber, pageSize, keyword));
            }
            ViewBag.Start = pageNumber * 10 - 9;
            if (pageNumber * 10 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 10;
            }
            return View(productsDao.GetSearchProducts(pageNumber, pageSize,keyword));
        }

    }
}