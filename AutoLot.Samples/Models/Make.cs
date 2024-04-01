namespace AutoLot.Samples.Models
{
    public class Make : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Car> Cars { get; set; } = [];
    }
}
