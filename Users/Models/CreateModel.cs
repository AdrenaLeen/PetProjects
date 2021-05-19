using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class CreateModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
