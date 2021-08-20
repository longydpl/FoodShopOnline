using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.Models.Dao
{
    public class OrderDetailDao
    {
        OnlineFoodShop db = null;

        public OrderDetailDao()
        {
            db = new OnlineFoodShop();
        }

        public bool Insert(OderDetail oderDetail)
        {
            try
            {
                db.OderDetails.Add(oderDetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}