namespace AutoLot.Samples.Models
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IEnumerable<Car> Cars { get; set; } = [];
    }
}
