using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.Models.Dao
{
    public class OrderDao
    {
        OnlineFoodShop db = null;
        public OrderDao()
        {
            db = new OnlineFoodShop();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}