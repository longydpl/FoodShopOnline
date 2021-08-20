namespace FoodShopOnline.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OderDetails = new HashSet<OderDetail>();
            Tags1 = new HashSet<Tag>();
        }

        public long ID { get; set; }


        [StringLength(250)]
        [Display(Name = "Tên sản phấm")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá giảm giá")]
        public decimal? PromotionPrice { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifliedDate { get; set; }

        [StringLength(250)]
        public string ModifliedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }
        [Display(Name = "Tình trạng")]
        public bool? Status { get; set; }
        [Display(Name = "Số lượt xem")]
        public int? CountView { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OderDetail> OderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags1 { get; set; }
    }
}
