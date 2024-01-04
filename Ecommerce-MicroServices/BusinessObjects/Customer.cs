using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }

    }
}