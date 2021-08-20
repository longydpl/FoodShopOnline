using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodShopOnline.Models.EF;
using PagedList;

namespace FoodShopOnline.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        private OnlineFoodShop db = new OnlineFoodShop();
        public ActionResult Index(int? page)
        {
            var news = db.News.Select(x => x);
            news = news.OrderBy(x => x.ID);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Detail(string metatitle)
        {
            var model = db.News.SingleOrDefault(x => x.MetaTitle == metatitle);
            if(model ==  null)
            {
                return HttpNotFound();
            }
            ViewBag.Lst = db.News.Where(x => x.MetaTitle != metatitle).ToList();
            return View(model);
        }


        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult PhiGiaoHang()
        {
            return View();
        }
    }
}