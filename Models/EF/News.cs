namespace FoodShopOnline.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            Tags1 = new HashSet<Tag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã tin tức")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string Detail { get; set; }
        [Display(Name = "Ngày tạo")]
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
        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }
        [Display(Name = "Số lượt xem")]
        public int? CountView { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags1 { get; set; }
    }
}
