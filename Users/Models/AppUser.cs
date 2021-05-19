using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public enum Cities
    {
        None, London, Paris, Chicago
    }

    public enum QualificationLevels
    {
        None, Basic, Advanced
    }

    public class AppUser : IdentityUser
    {
        [Display(Name = "Город")]
        public Cities City { get; set; }

        [Display(Name = "Уровень квалификации")]
        public QualificationLevels Qualifications { get; set; }
    }
}
