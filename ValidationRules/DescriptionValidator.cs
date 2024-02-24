using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    class DescriptionValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string desc = (string)value;
            if (string.IsNullOrEmpty(desc))
                return new ValidationResult(false, "Обов'язкове для заповнення");

            if (!Validator.SymbolCountsCheck(desc, 800, 10))
                return new ValidationResult(false, "Поле повинна бути заповненним від 10 до 800 символів");
            
            return ValidationResult.ValidResult;
        }
    }
}
