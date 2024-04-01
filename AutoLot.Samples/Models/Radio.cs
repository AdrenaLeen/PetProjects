namespace AutoLot.Samples.Models
{
    public class Radio : BaseEntity
    {
        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        public string RadioId { get; set; } = string.Empty;
        public int CarId { get; set; }
        public Car CarNavigation { get; set; } = new Car();
    }
}
