using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    // Этот класс описывает точку.
    class PointDescription
    {
        public string PetName { get; set; }
        public Guid PointID { get; set; }

        public PointDescription()
        {
            PetName = "Безымянный";
            PointID = Guid.NewGuid();
        }
    }
}
