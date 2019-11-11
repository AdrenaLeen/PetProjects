using System.ComponentModel.DataAnnotations;

namespace AutoLotDALCore.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
