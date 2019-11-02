using PropertyChanged;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AutoLotDAL.Models
{
    [AddINotifyPropertyChangedInterface]
    public class EntityBase : IDataErrorInfo, INotifyDataErrorInfo
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }

        [NotMapped]
        public bool IsChanged { get; set; }

        protected readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Count != 0;

        public string Error { get; }

        public virtual string this[string columnName] => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return errors.Values;
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }

        protected void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        protected void ClearErrors(string propertyName = "")
        {
            errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        protected void AddError(string propertyName, string error) => AddErrors(propertyName, new List<string> { error });

        protected void AddErrors(string propertyName, IList<string> myErrors)
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

        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext vc = new ValidationContext(this, null, null) { MemberName = propertyName };
            bool isValid = Validator.TryValidateProperty(value, vc, results);
            return isValid ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }
    }
}
