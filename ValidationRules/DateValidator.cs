using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    public class DateValidator : ValidationRule
    {
        public bool CanBeEmpty { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string date = (string)value;

            if (!CanBeEmpty && string.IsNullOrEmpty(date))
                return new ValidationResult(false, "Обов'язкове для заповнення");

            if (!Validator.HasDotDate(date))
                return new ValidationResult(false, "Дата повинна містити формат дд.мм.рррр");

            if (!Validator.HasLimitDate(date))
                return new ValidationResult(false, "Дата має містити діапазонний формат чисел та цифр, наприклад: дд(01-31).мм(01-12).рррр(1900-2099)");

            return ValidationResult.ValidResult;
        }
    }
}