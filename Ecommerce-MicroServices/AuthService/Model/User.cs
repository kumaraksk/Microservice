using System.ComponentModel.DataAnnotations;

namespace AuthService.Model
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
