using System;

// Обеспечить совместимость с CLS для всех открытых типов в этой сборке.
[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    // Специальный атрибут.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription) => Description = vehicalDescription;

        public VehicleDescriptionAttribute() { }
    }
}
