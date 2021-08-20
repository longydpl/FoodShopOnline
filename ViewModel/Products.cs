using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.ViewModel
{
    public class Products
    {
        public long? ID { set; get; }
        public string ProductName { set; get; }

        public string Url { set; get; }

        public decimal? Price { get; set; }

        public string Image { set; get; }

        public string CategoryName { set; get; }

        public DateTime? CreateDate { set; get; }

        public string Description { set; get; }

        public int? CountView { set; get; }
    }
}