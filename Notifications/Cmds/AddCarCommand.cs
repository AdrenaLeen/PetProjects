using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Models;

namespace Notifications.Cmds
{
    internal class AddCarCommand : CommandBase
    {
        private readonly IList<Inventory> cars;

        public AddCarCommand(IList<Inventory> myCars) => cars = myCars;

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            int maxCount = cars?.Max(x => x.CarId) ?? 0;
            cars?.Add(new Inventory { CarId = ++maxCount, Color = "Жёлтый", Make = "VW", PetName = "Пташка", IsChanged = false });
        }
    }
}
