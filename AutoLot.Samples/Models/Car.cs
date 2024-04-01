using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Samples.Models
{
    [Table("Inventory", Schema = "public")]
    [Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
    public class Car : BaseEntity
    {
        private bool? _isDriveable;

        [Required, StringLength(50)]
        public string Color { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string PetName { get; set; } = string.Empty;

        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make MakeNavigation { get; set; } = new Make();

        public Radio RadioNavigation { get; set; } = new Radio();

        [InverseProperty(nameof(Driver.Cars))]
        public IEnumerable<Driver> Drivers { get; set; } = [];

        public DateTime DateBuilt { get; set; }

        public bool IsDriveable
        {
            get => _isDriveable ?? true;
            set => _isDriveable = value;
        }

        public string DisplayName { get; set; } = string.Empty;
    }
}
