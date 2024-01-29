using System.Globalization;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules;

public class LoginValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string password = (string)value;

        if (!Validator.HasNumber(password))
            return new ValidationResult(false, "Пароль повинен містити мінімум одну цифру");

        if (!Validator.HasLowerChar(password))
            return new ValidationResult(false, "Пароль повинен містити букви у нижньому регістрі");

        if (!Validator.HasUpperChar(password))
            return new ValidationResult(false, "Пароль повинен містити букви у верхньому регістрі");

        if (Validator.HasIncorrectSymbols(password))
            return new ValidationResult(false, @"Пароль не може містити наступні символи { } / \ [ ] < >");

        if (!Validator.IsCorrectLength(password, 8, 16))
            return new ValidationResult(false, "Пароль повинен містити від 8 до 16 символів");
        
        return ValidationResult.ValidResult;
    }
}