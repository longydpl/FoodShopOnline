using FoodShopOnline.Areas.Admin.Data;
using FoodShopOnline.Common;
using FoodShopOnline.Models.Dao;
using System.Web.Mvc;


namespace FoodShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var admin = dao.GetByID(model.Username);
                    var userSession = new AdminLogin();
                    userSession.Username = admin.Username;
                    userSession.AdminID = admin.ID;
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return View("Index");
        }
    }
}