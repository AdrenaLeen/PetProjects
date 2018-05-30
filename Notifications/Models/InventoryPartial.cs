using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        errors = GetErrorsFromAnnotations(nameof(CarId), CarId);
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make), "Слишком старая");
                            hasError = true;
                        }
                        errors = GetErrorsFromAnnotations(nameof(Make), Make);
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        errors = GetErrorsFromAnnotations(nameof(Color), Color);
                        break;
                    case nameof(PetName):
                        errors = GetErrorsFromAnnotations(nameof(PetName), PetName);
                        break;
                }
                if (errors != null && errors.Length != 0)
                {
                    AddErrors(columnName, errors);
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }

        public string Error { get; }

        internal bool CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Розовый")
            {
                AddError(nameof(Make), $"{Make} не поставляется в цвете {Color}");
                AddError(nameof(Color), $"{Make} не поставляется в цвете {Color}");
                return true;
            }
            return false;
        }
    }
}
