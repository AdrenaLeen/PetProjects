using System.ComponentModel.DataAnnotations;

namespace Cities.Models
{
    public class City
    {
        [Display(Name = "Город")]
        public string Name { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Население")]
        public int? Population { get; set; }

        [Display(Name = "Заметки")]
        public string Notes { get; set; }
    }
}
