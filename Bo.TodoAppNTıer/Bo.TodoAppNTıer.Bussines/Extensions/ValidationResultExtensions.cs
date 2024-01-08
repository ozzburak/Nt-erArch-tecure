using Bo.ToDoAppNTİer.Common.ResponseObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Bussines.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();


            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    Message = error.ErrorMessage,
                    PropertyName = error.PropertyName,
                });
            }
            return errors;
        }
    }
}
