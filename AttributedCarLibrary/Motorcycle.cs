using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    // Назначить описание с помощью "именованного свойства".
    [Serializable]
    [VehicleDescription(Description = "Мой звёздный Харлей")]
    public class Motorcycle
    {
    }
}
