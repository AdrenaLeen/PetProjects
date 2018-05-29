using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class Inventory : INotifyPropertyChanged
    {
        private int carId;
        public int CarId
        {
            get { return carId; }
            set
            {
                if (value == carId) return;
                carId = value;
                OnPropertyChanged();
            }
        }

        private string make;
        public string Make
        {
            get { return make; }
            set
            {
                if (value == make) return;
                make = value;
                OnPropertyChanged();
            }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                if (value == color) return;
                color = value;
                OnPropertyChanged();
            }
        }

        private string petName;
        public string PetName
        {
            get { return petName; }
            set
            {
                if (value == petName) return;
                petName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
