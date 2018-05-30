using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Notifications.Models;

namespace Notifications.Cmds
{
    internal class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Inventory) != null;

        public override void Execute(object parameter) => ((Inventory)parameter).Color = "Розовый";
    }
}
