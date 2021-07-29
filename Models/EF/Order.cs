namespace FoodShopOnline.Models.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OderDetails = new HashSet<OderDetail>();
        }

        public long ID { get; set; }

        public long? UserID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(500)]
        public string ShipAddress { get; set; }

        [StringLength(10)]
        public string ShipPhone { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OderDetail> OderDetails { get; set; }

        public virtual User User { get; set; }
    }
}
