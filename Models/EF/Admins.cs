namespace FoodShopOnline.Models.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Admin")]
    public partial class Admins
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Họ tên trống")]
        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tài khoản trống")]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu trống")]
        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Loại tài khoản")]
        public bool Type { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }
    }
}
