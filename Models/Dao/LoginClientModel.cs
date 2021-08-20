using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodShopOnline.Models.Dao
{
    public class LoginClientModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}