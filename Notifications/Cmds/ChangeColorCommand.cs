using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Notifications.Models;

namespace Notifications.Cmds
{
    class ChangeColorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => (parameter as Inventory) != null;

        public void Execute(object parameter) => ((Inventory)parameter).Color = "Розовый";
    }
}
