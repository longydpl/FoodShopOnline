using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShopOnline.Models.EF;
using FoodShopOnline.ViewModel;

namespace FoodShopOnline.Models.Dao
{
    public class OrderDetailModel
    {
        OnlineFoodShop db = null;
        public OrderDetailModel()
        {
            db = new OnlineFoodShop();
        }

        public List<FoodShopOnline.ViewModel.OrderDetails> GetListByID(long? id)
        {
            var model = from a in db.OderDetails
                        join b in db.Orders
                        on a.OrderID equals b.ID
                        join c in db.Products
                        on a.ProductID equals c.ID
                        where a.OrderID == id
                        select new ViewModel.OrderDetails()
                        {
                            ID = a.OrderID,
                            ProductName = c.Name,
                            Quantity = a.Quantity,
                            Price = c.Price
                        };
            return model.ToList();
        }

        public void DeleteByID(long? id)
        {
            var orders = db.OderDetails.Where(o => o.OrderID == id);
            foreach(var item in orders)
            {
                db.OderDetails.Remove((OderDetail)item);
            }
            db.SaveChanges();
        }
    }
}