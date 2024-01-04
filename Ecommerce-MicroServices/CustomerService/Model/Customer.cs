using CustomerService.Interface;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.Model
{
    public class Customer : IDelete
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
