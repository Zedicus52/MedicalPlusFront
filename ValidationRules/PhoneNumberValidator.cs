using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    public class PhoneNumberValidator : ValidationRule
    {

        public bool CanBeEmpty { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phoneNumber = (string)value;

            if (!CanBeEmpty && string.IsNullOrEmpty(phoneNumber))
                return new ValidationResult(false, "Обов'язкове для заповнення");

            if (!Validator.IsCorrectLength(phoneNumber, 9, 12))
                return new ValidationResult(false, "Номер має містити від 9 до 12 цифр");

            if (!Validator.HasCheckNumber(phoneNumber))
                return new ValidationResult(false, "Номер повинен містити тільки цифри");

            return ValidationResult.ValidResult;
        }
    }
}
