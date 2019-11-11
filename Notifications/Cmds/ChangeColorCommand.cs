using AutoLotDAL.Models;

namespace Notifications.Cmds
{
    internal class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Inventory) != null;

        public override void Execute(object parameter) => ((Inventory)parameter).Color = "Розовый";
    }
}
