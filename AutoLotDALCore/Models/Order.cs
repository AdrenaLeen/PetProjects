using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALCore.Models
{
    public partial class Order : EntityBase
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [ForeignKey(nameof(CarId))]
        public Inventory Car { get; set; }
    }
}
