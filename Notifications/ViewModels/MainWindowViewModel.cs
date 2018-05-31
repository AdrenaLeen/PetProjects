using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Models;

namespace Notifications.ViewModels
{
    public class MainWindowViewModel
    {
        public IList<Inventory> Cars { get; set; }

        public MainWindowViewModel()
        {
            Cars = new ObservableCollection<Inventory>
            {
                new Inventory{CarId=1, Color="Голубой", Make="Chevy", PetName="Кит", IsChanged=false},
                new Inventory{CarId=2, Color="Красный", Make="Ford", PetName="Красный всадник", IsChanged=false}
            };
        }
    }
}
