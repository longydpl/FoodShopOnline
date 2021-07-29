using System.ComponentModel.DataAnnotations;

namespace FoodShopOnline.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}