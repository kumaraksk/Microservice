using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Categories")]
    public class Categrory
    {
        [Key]
        public long CategroryId { get; set; }
        public string CategoryName { get; set; }
        public long? ParentCategroryId { get; set; }
        [ForeignKey("ParentCategroryId")]
        public Categrory ParentCategrory { get; set; }
    }
}