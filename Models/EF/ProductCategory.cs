namespace FoodShopOnline.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public long ID { get; set; }

        [Required(ErrorMessage ="Tên danh mục trống")]
        [StringLength(250)]
        [Display(Name ="Tên danh mục")]
        public string Name { get; set; }
        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Metatitle trống")]
        [StringLength(250)]
        public string MetaTitle { get; set; }
        [Display(Name = "Mã danh mục cha")]
        public long? ParentID { get; set; }

        [StringLength(500)]
        [Display(Name ="Mô tả")]
        public string Description { set; get; }
        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifliedDate { get; set; }

        [StringLength(250)]
        public string ModifliedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
