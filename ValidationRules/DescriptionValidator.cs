using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    public class DescriptionValidator : ValidationRule
    {
        public bool CanBeEmpty { get; set; }
        public int MinCount { get; set; } = 10;
        public int MaxCount { get; set; } = 200;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string desc = (string)value;
            if (!CanBeEmpty && string.IsNullOrEmpty(desc))
                return new ValidationResult(false, "Обов'язкове для заповнення");

            if (!Validator.SymbolCountsCheck(desc, MaxCount, MinCount))
                return new ValidationResult(false, $"Поле повинна бути заповненним від {MinCount} до {MaxCount} символів");
            
            return ValidationResult.ValidResult;
        }
    }
}
