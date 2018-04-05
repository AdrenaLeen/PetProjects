using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Inventory
    {
        public override string ToString()
        {
            // Поскольку столбец PetName может быть пустым, предоставим стандартное имя **Безымянный**.
            return $"{PetName ?? "**Безымянный**"} - это {Color} {Make} с ID {CarId}.";
        }

        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";
    }
}
