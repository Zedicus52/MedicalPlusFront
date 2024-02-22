using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalPlusFront.ValidationRules;

public static partial class Validator
{
    public static bool HasNumber(string input) => NumberRegex().IsMatch(input);

    public static bool HasUpperChar(string input) => UpperCharRegex().IsMatch(input);

    public static bool HasLowerChar(string input) => LowerCharRegex().IsMatch(input);

    public static bool HasIncorrectSymbols(string input) => IncorrectSymbolsRegex().IsMatch(input);
    
    public static bool HasOnlyEnglishLetters(string input) => OnlyEnglishLetters().IsMatch(input);

    public static bool HasDotDate(string input) => DateDotRegex().IsMatch(input);

    public static bool HasLimitDate(string input) => LimitDateNumbers().IsMatch(input);

    public static bool HasCheckSpace(string input) => CheckSpace().IsMatch(input);

    public static bool HasOnlyLettersAndSpace(string input) => OnlyLettersAndSpaceBetweenText().IsMatch(input);

    public static bool HasCheckNumber(string input) => CheckNumber().IsMatch(input);

    public static bool IsCorrectLength(string input, int minLength, int maxLenght)
    {
        int length = input.Length;
        return length >= minLength && length <= maxLenght;
    }

    [GeneratedRegex("[0-9]+")]
    private static partial Regex NumberRegex();
    
    [GeneratedRegex(@"[A-Z]")]
    private static partial Regex UpperCharRegex();
    
    [GeneratedRegex("[a-z]+")]
    private static partial Regex LowerCharRegex();

    [GeneratedRegex("[^a-zA-Z]")]
    private static partial Regex OnlyEnglishLetters();

    [GeneratedRegex(@"[{}\\[\\]/\\\\<>'""]")]
    private static partial Regex IncorrectSymbolsRegex();

    [GeneratedRegex(@"\d{2}\.\d{2}\.\d{4}")]
    private static partial Regex DateDotRegex();

    [GeneratedRegex(@"^0[1-9]|[12][0-9]|3[01]\.(0[1-9]1[0-2])\.(19\d{2}|20\d{2})$")]
    private static partial Regex LimitDateNumbers();

    [GeneratedRegex(@"^\s|s$")]
    private static partial Regex CheckSpace();

    [GeneratedRegex(@"[Р-пр-џ\s]*")]
    private static partial Regex OnlyLettersAndSpaceBetweenText();

    [GeneratedRegex(@"^\d+$")]
    private static partial Regex CheckNumber();
}