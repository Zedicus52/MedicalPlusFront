using System.Globalization;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules
{
    public class ResearchValidator : ValidationRule
    {
        public bool CanBeEmpty { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string researchNum = (string)value;

            if (!CanBeEmpty && string.IsNullOrEmpty(researchNum))
                return new ValidationResult(false, "Обов'язкове поле для заповнення");

            if (!Validator.HasResearchNumber(researchNum))
                return new ValidationResult(false, "Поле повинна приймати два числа та риску між ними, наприклад: 12-324");

            return ValidationResult.ValidResult;
        }
    }
}
