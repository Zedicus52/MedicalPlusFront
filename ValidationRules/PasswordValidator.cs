using System.Globalization;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules;

public class PasswordValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string password = (string)value;

        /*if (!Validator.HasOnlyEnglishLetters(password))
            return new ValidationResult(false, "Пароль повинен містити тільки латинські літери");*/
        if (string.IsNullOrEmpty(password))
            return new ValidationResult(false, "Обов'язкове для заповнення");
        
        if (!Validator.IsCorrectLength(password, 8, 16))
            return new ValidationResult(false, "Пароль повинен містити від 8 до 16 символів");
        
        if (!Validator.HasUpperChar(password))
            return new ValidationResult(false, "Пароль повинен містити мінімум одну букву у верхньому регістрі");
        
        if (!Validator.HasLowerChar(password))
            return new ValidationResult(false, "Пароль повинен містити мінімум одну букву у нижньому регістрі");
        
        if (!Validator.HasNumber(password))
            return new ValidationResult(false, "Пароль повинен містити мінімум одну цифру");
        
        if (Validator.HasIncorrectSymbols(password))
            return new ValidationResult(false, @"Пароль не може містити наступні символи { } / \ [ ] < > ' "" ");
        
        return ValidationResult.ValidResult;
    }
}