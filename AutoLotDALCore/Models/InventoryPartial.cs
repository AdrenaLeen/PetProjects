using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALCore.Models
{
    [ModelMetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        // Поскольку столбец PetName может быть пустым, определить стандартное имя **No Name**.
        public override string ToString() => $"{PetName ?? "**No Name**"} - это {Color} {Make} с ID {Id}.";
        
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";
    }
}
