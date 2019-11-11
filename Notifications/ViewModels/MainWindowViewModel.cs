using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using Notifications.Cmds;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Notifications.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Inventory> Cars { get; set; }
        private ICommand changeColorCommand = null;
        private ICommand removeCarCommand = null;
        private ICommand addCarCommand = null;

        public MainWindowViewModel()
        {
            using (InventoryRepo inventoryRepo = new InventoryRepo())
            {
                Cars = new ObservableCollection<Inventory>(inventoryRepo.GetAll());
            }
        }

        public ICommand ChangeColorCmd => changeColorCommand ?? (changeColorCommand = new ChangeColorCommand());
        public ICommand RemoveCarCmd => removeCarCommand ?? (removeCarCommand = new RemoveCarCommand(Cars));
        public ICommand AddCarCmd => addCarCommand ?? (addCarCommand = new AddCarCommand(Cars));
    }
}
