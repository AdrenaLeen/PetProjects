namespace AutoLot.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public int MakeId { get; set; }
        public string PetName { get; set; } = string.Empty;
    }
}
