﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary
{
    [VehicleDescription("Очень длинное, медленное, но многофункциональное авто")]
    public class Winnebago
    {
        // Тип ulong не соответствует спецификации CLS.
        public ulong notCompliant;
    }
}
