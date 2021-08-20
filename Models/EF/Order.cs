namespace FoodShopOnline.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OderDetails = new HashSet<OderDetail>();
        }

        public long ID { get; set; }
        [Display(Name = "Mã khách hàng")]
        public long? UserID { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string ShipName { get; set; }

        [StringLength(500)]
        [Display(Name = "Địa chỉ")]
        public string ShipAddress { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string ShipPhone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string ShipEmail { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string Notes { get; set; }
        [Display(Name = "Đã giao")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}
