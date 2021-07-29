namespace FoodShopOnline.Models.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OderDetail")]
    public partial class OderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductID { get; set; }

        public int? Quantity { get; set; }

        public bool Status { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
