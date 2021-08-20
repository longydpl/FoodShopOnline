using FoodShopOnline.Common;
using FoodShopOnline.Models.Dao;
using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShopOnline.Controllers
{
    public class UserController : Controller
    {
        private OnlineFoodShop db = new OnlineFoodShop();
        // GET: User
        public ActionResult RegisterIndex()
        {
            return View();
        }


        public ActionResult LoginIndex()
        {
            return View();
        }


        public ActionResult Login(LoginClientModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.Username);
                    var userSession = new UserLogin();
                    userSession.Username = user.Username;
                    userSession.UserID = user.ID;
                    userSession.Name = user.Name;
                    userSession.Phone = user.Phone;
                    userSession.Address = user.Address;
                    userSession.Email = user.Email;
                    Session.Add(CommonConstants.CLIENT_SESSION, userSession);
                    return RedirectToRoute("TrangChu");
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
            return View("LoginIndex");
        }


        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,Status,CreatedDate,CreateBy,ModifliedDate,ModifliedBy")] User user)
        {
            try
            {
                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                user.CreatedDate = DateTime.Now;
                user.Status = true;
                var userName = db.Users.SingleOrDefault(x => x.Username == user.Username);
                if (userName != null) throw new Exception("Tài khoản đã tồn tại");
                foreach(char c in user.Phone)
                {
                    if (!Char.IsDigit(c)) throw new Exception("Số điện thoại nhập không đúng định dạng");
                }
                if(ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("RegisterIndex");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.CLIENT_SESSION] = null;
            return RedirectToRoute("TrangChu");
        }
    }
}