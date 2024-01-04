using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
        public long CustomerId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }

    }
}