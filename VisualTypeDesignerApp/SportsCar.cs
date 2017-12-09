using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualTypeDesignerApp
{
    public class SportsCar : Car
    {
        public string GetPetName()
        {
            petName = "Фред";
            return petName;
        }
    }
}