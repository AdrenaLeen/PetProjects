using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    [Serializable]
    [Obsolete("Используйте другое транспортное средство!")]
    [VehicleDescription("Старая серая кобыла, она не та, чем была раньше...")]
    public class HorseAndBuggy
    {
    }
}
