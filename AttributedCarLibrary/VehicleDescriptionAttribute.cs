using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    // Специальный атрибут.
    public class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }

        public VehicleDescriptionAttribute() { }
    }
}
