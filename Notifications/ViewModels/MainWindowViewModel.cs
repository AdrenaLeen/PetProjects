﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Notifications.Models;
using Notifications.Cmds;

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
            Cars = new ObservableCollection<Inventory>
            {
                new Inventory{CarId=1, Color="Голубой", Make="Chevy", PetName="Кит", IsChanged=false},
                new Inventory{CarId=2, Color="Красный", Make="Ford", PetName="Красный всадник", IsChanged=false}
            };
        }

        public ICommand ChangeColorCmd => changeColorCommand ?? (changeColorCommand = new ChangeColorCommand());
        public ICommand RemoveCarCmd => removeCarCommand ?? (removeCarCommand = new RemoveCarCommand(Cars));
        public ICommand AddCarCmd => addCarCommand ?? (addCarCommand = new AddCarCommand(Cars));
    }
}
