using FoodShopOnline.Models.Dao;
using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FoodShopOnline.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }


        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductsDao().ViewDetail(productID);
            var cart = Session[Common.CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x => x.Product.ID ==productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[Common.CommonConstants.CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[Common.CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[Common.CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });             
        }

        public JsonResult DeleteAll()
        {
            Session[Common.CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[Common.CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            if(Session[Common.CommonConstants.CLIENT_SESSION] != null)
            {
                ViewBag.User = Session[Common.CommonConstants.CLIENT_SESSION];
            }
            else
            {
                ViewBag.User = null;
            }
            return View(list);
        }    

        [HttpPost]
        public ActionResult Payment(string shipName,string address, string phone, string email)
        {
            try
            {
                //Tao 1 don hang moi
                if (shipName.Trim().Equals("")) throw new Exception("Tên người nhận trống!");
                if (address.Trim().Equals("")) throw new Exception("Địa chỉ trống!");
                if (phone.Trim().Equals("")) throw new Exception("Số điện thoại trống!");
                foreach (char c in shipName)
                {
                    if (!char.IsWhiteSpace(c) && !char.IsLetter(c)) throw new Exception("Tên người nhận sai định dạng!");
                }
                foreach (char c in phone)
                {
                    if (char.IsWhiteSpace(c) || !char.IsDigit(c)) throw new Exception("Số điện thoại sai định dạng!");
                }
                var order = new Order();
                order.ShipAddress = address;
                order.ShipName = shipName;
                order.ShipPhone = phone;
                order.ShipEmail = email;
                if(ModelState.IsValid)
                {
                    var id = new OrderDao().Insert(order);
                    //Tao thong tin don hang
                    var cart = (List<CartItem>)Session[Common.CommonConstants.CartSession];
                    var detailDao = new OrderDetailDao();
                    foreach (var item in cart)
                    {
                        var oderDetail = new OderDetail();
                        oderDetail.Quantity = item.Quantity;
                        oderDetail.ProductID = item.Product.ID;
                        oderDetail.OrderID = id;
                        detailDao.Insert(oderDetail);
                    }
                }    
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var cart = Session[Common.CommonConstants.CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            Session[Common.CommonConstants.CartSession] = null;
            return View();
        }


        public ActionResult AddItems(string gtri ="",string gtri1 = "")
        {
            if(!gtri1.Equals(""))
            {
                gtri = gtri1;
            }
            if(!gtri.Equals(""))
            {
                List<int> lst = new List<int>();
                string[] arrListStr = gtri.Trim().Split(' ');
                foreach (string item in arrListStr)
                {
                    lst.Add(Convert.ToInt32(item));
                }
                foreach (int productID in lst)
                {
                    var product = new ProductsDao().ViewDetail(productID);
                    var cart = Session[Common.CommonConstants.CartSession];
                    if (cart != null)
                    {
                        var list = (List<CartItem>)cart;
                        if (list.Exists(x => x.Product.ID == productID))
                        {
                            foreach (var item in list)
                            {
                                if (item.Product.ID == productID)
                                {
                                    item.Quantity += 1;
                                }
                            }
                        }
                        else
                        {
                            var item = new CartItem();
                            item.Product = product;
                            item.Quantity = 1;
                            list.Add(item);
                        }
                        Session[Common.CommonConstants.CartSession] = list;
                    }
                    else
                    {
                        // Tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = 1;
                        var list = new List<CartItem>();
                        list.Add(item);
                        //Gán vào session
                        Session[Common.CommonConstants.CartSession] = list;
                    }
                }
            }
            else
            {
                ViewBag.Error = "Mời chọn mặt hàng";
            }
            return RedirectToAction("Index");
        }
    }
}