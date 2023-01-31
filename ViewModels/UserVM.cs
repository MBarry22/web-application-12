using System.ComponentModel.DataAnnotations;

namespace WebApplication12.ViewModels
{
    public class UserVM
    {
        [Key]
        public string Email { get; set; }
    }
}
