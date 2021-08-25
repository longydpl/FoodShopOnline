using System.Web.Mvc;
using System.Web.Routing;

namespace FoodShopOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.IgnoreRoute("{*botdetect}",
      new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "ThanhToan",
               url: "thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );
            routes.MapRoute(
               name: "Gio Hang",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "DangKyTc",
               url: "dang-ky-thanh-cong",
               defaults: new { controller = "User", action = "RegisterIndex", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );
            routes.MapRoute(
               name: "TatCaMonAn",
               url: "tat-ca-mon-an",
               defaults: new { controller = "Product", action = "AllProduct", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );


            routes.MapRoute(
               name: "NewProducts",
               url: "mon-moi",
               defaults: new { controller = "Product", action = "NewProducts", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "SpecialProducts",
               url: "mon-dac-biet",
               defaults: new { controller = "Product", action = "SpecialProducts", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );


            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "TrangChu",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Feedbacks", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Contact1",
                url: "lien-he-thanh-cong",
                defaults: new { controller = "Feedbacks", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "News",
                url: "tin-tuc",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "NewsDetail",
                url: "tin-tuc/{metatitle}",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "PhiGiaoHang",
                url: "phi-giao-hang",
                defaults: new { controller = "News", action = "PhiGiaoHang", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );


            routes.MapRoute(
                name: "GioiThieu",
                url: "gioi-thieu",
                defaults: new { controller = "News", action = "GioiThieu", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "ChinhSach",
                url: "chinh-sach",
                defaults: new { controller = "News", action = "ChinhSach", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "BanDo",
                url: "ban-do",
                defaults: new { controller = "Feedbacks", action = "Map", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "ChinhSachDetial",
                url: "chinh-sach/{metatitle}",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );



            routes.MapRoute(
                name: "CartUpdate",
                url: "gio-hang/update",
                defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "CartDeleteAll",
                url: "gio-hang/deleteall",
                defaults: new { controller = "Cart", action = "DeleteAll", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "CartDelete",
                url: "gio-hang/delete",
                defaults: new { controller = "Cart", action = "Delete", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "AddItems",
                url: "them-gio-hang-all",
                defaults: new { controller = "Cart", action = "AddItems", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );


            routes.MapRoute(
                name: "Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "ProductCategory",
                url: "{metatitle}",
                defaults: new { controller = "Product", action = "ListProductByCategoryID", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "ProductDetail",
                url: "{metatitle}/{metatitle1}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FoodShopOnline.Controllers" }
            );
        }
    }
}
