using System.Text.RegularExpressions;

namespace MedicalPlusFront.ValidationRules;

public static partial class Validator
{
    public static bool HasNumber(string input) => NumberRegex().IsMatch(input);

    public static bool HasUpperChar(string input) => UpperCharRegex().IsMatch(input);

    public static bool HasLowerChar(string input) => LowerCharRegex().IsMatch(input);

    public static bool HasIncorrectSymbols(string input) => IncorrectSymbolsRegex().IsMatch(input);
    
    public static bool HasOnlyEnglishLetters(string input) => OnlyEnglishLetters().IsMatch(input);

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


}