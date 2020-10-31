using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Пожалуйста, введите своё имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой адрес электронной почты")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примете ли участие")]
        public bool? WillAttend { get; set; }
    }
}
