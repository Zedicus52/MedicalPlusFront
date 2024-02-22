using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    internal class FioValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string fullName = (string)value;

            if (string.IsNullOrEmpty(fullName))
                return new ValidationResult(false, "Обов'язкове для заповнення");

            if (Validator.HasCheckSpace(fullName))
                return new ValidationResult(false, "ПІБ не повинен містити пробели в початку чи в кінці текста");

            if (!Validator.HasOnlyLettersAndSpace(fullName))
                return new ValidationResult(false, "ПІБ повинен містити в собі букви кирилиці та пробіл між назвами особи");

            return ValidationResult.ValidResult;
        }
    }
}
