using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Models;

namespace Notifications.Cmds
{
    internal class RemoveCarCommand : CommandBase
    {
        private readonly IList<Inventory> cars;

        public RemoveCarCommand(IList<Inventory> myCars) => cars = myCars;

        public override bool CanExecute(object parameter) => ((parameter as Inventory) != null) && (cars != null) && (cars.Count != 0);

        public override void Execute(object parameter) => cars.Remove((Inventory)parameter);
    }
}
