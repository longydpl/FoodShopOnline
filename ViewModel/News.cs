using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.ViewModel
{
    public class News
    {
        public long? ID { set; get; }
        public string Name { set; get; }
        public string Detail { set; get; }
        public DateTime CreateDate { set; get; }
        public string Image { set; get; }

    }
}