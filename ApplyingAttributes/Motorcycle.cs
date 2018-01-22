using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    // Этот класс может быть сохранён на диске.
    [Serializable]
    class Motorcycle
    {
        // Однако это поле сохраняться не будет.
        [NonSerialized]
        float weightOfCurrentPassengers;

        // Эти поля остаются сериализируемыми.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
