using System;
using FluentValidation.Results;
using System.Text;

namespace Base.DataModel.Context.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string ToMessage(this IList<ValidationFailure> errors)
        {
            var result = new StringBuilder();
            foreach (var error in errors)
            {
                result.AppendLine($"{error.ErrorMessage} {error.AttemptedValue}");
            }
            return result.ToString();
        }

        public static Dictionary<string, string> ToMessageDictionary(this IList<ValidationFailure> errors)
        {
            var result = new Dictionary<string, string>();
            foreach (var error in errors)
            {
                result.Add(error.PropertyName, error.ErrorMessage);
            }
            return result;
        }


    }
}

