using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace FoodShopOnline.Models.Dao
{
    public class NewsDao
    {
        OnlineFoodShop db = null;

        public NewsDao()
        {
            db = new OnlineFoodShop();
        }
    }
}