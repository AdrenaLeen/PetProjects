using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelValidation.Infrastructure
{
    public class MustBeTrue : Attribute, IModelValidator
    {
        public bool IsRequired => true;

        public string ErrorMessage { get; set; } = "Это значение должно быть истиной";

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            bool? value = context.Model as bool?;
            if (!value.HasValue || value.Value == false) return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
            else return Enumerable.Empty<ModelValidationResult>();            
        }
    }
}
