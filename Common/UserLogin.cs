using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShopOnline.Common
{
    public class UserLogin
    {
        public long UserID { set; get; }
        public string Username { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
    }
}