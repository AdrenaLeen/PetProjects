using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public partial class Inventory : INotifyDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CarId):
                        break;
                    case nameof(Make):
                        if (Make == "ModelT") return "Слишком старая";
                        return CheckMakeAndColor();
                    case nameof(Color):
                        return CheckMakeAndColor();
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }

        public string Error { get; }

        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Count != 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return errors.Values;
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }

        internal string CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Розовый") return $"{Make} не поставляется в цвете {Color}";
            return string.Empty;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearErrors(string propertyName = "")
        {
            errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> { error });
        }

        private void AddErrors(string propertyName, IList<string> myErrors)
        {
            bool changed = false;
            if (!errors.ContainsKey(propertyName))
            {
                errors.Add(propertyName, new List<string>());
                changed = true;
            }
            myErrors.ToList().ForEach(x =>
            {
                if (errors[propertyName].Contains(x)) return;
                errors[propertyName].Add(x);
                changed = true;
            });
            if (changed) OnErrorsChanged(propertyName);
        }
    }
}
