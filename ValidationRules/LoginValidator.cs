using System.Globalization;
using System.Windows.Controls;

namespace MedicalPlusFront.ValidationRules;

public class LoginValidator: ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string login = (string)value;

        if (string.IsNullOrEmpty(login))
            return new ValidationResult(false, "Обов'язкове для заповнення");
        /*if (Validator.HasOnlyEnglishLetters(login))
            return new ValidationResult(false, "Логін повинен містити тільки латинські літери");*/
        
        if (!Validator.IsCorrectLength(login, 1, 15))
            return new ValidationResult(false, "Логін повинен містити від 6 до 15 символів");
        
        if (!Validator.HasUpperChar(login))
            return new ValidationResult(false, "Логін повинен містити мінімум одну букву у верхньому регістрі");
        
        if (!Validator.HasLowerChar(login))
            return new ValidationResult(false, "Логін повинен містити мінімум одну букву у нижньому регістрі");
        
        if (Validator.HasIncorrectSymbols(login))
            return new ValidationResult(false, @"Пароль не може містити наступні символи { } / \ [ ] < > ' "" ");
        
        return ValidationResult.ValidResult;
    }
}