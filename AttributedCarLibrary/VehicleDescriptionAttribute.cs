namespace AttributedCarLibrary
{
    // Специальный атрибут.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; } = string.Empty;

        public VehicleDescriptionAttribute(string vehicalDescription) => Description = vehicalDescription;

        public VehicleDescriptionAttribute() { }
    }
}
