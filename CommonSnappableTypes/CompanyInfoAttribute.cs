namespace CommonSnappableTypes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CompanyInfoAttribute : Attribute
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyUrl { get; set; } = string.Empty;
    }
}
