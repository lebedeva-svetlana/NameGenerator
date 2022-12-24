using System;
using System.Globalization;
using System.Windows.Controls;

namespace View
{
    internal class IntValidationRule : ValidationRule
    {
        public Type ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            }

            switch (ValidationType.Name)
            {
                case "Int32":

                    bool canConvert = int.TryParse(stringValue, out _);

                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int32");

                default:

                    throw new InvalidCastException($"{ValidationType.Name} is not supported");
            }
        }
    }
}