using System.ComponentModel.DataAnnotations;

namespace AutoLotDALCore.Models
{
    public class InventoryMetaData
    {
        [Display(Name = "Дружественное имя")]
        public string PetName;

        [StringLength(50, ErrorMessage = "Пожалуйста, введите значение длиной менее 50 символов.")]
        public string Make;
    }
}
