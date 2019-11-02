using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Inventory
    {
        public override string ToString() =>
            // Поскольку столбец PetName может быть пустым, предоставим стандартное имя **Безымянный**.
            $"{PetName ?? "**Безымянный**"} - это {Color} {Make} с ID {CarId}.";

        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";

        public override string this[string columnName]
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
