using FoodShopOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.Models.Dao
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}