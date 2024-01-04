using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public long CategroryId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }

    }
}