using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.ViewModel
{
    public class OrderDetails
    {
        public long? ID { set; get; }
        public string ProductName { set; get; }
        public int? Quantity { set; get; }
        public decimal? Price { set; get; }

    }
}