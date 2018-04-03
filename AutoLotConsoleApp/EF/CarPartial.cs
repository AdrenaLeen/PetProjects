using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotConsoleApp.EF
{
    public partial class Car
    {
        public override string ToString()
        {
            // Поскольку столбец PetName может быть пустым, предоставить стандартное имя **Безымянный**.
            return $"{CarNickName ?? "**Безымянный**"} - это {Color} {Make} с ID {CarId}.";
        }
    }
}
