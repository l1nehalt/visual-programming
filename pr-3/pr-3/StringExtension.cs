namespace pr_3;

public static class StringExtension
{
    public static void GetInfo(this string str)
    {
        var stringInfo = new StringInfo
        {
            Length = str.Length,
            CountOfDigits = str.Count(char.IsDigit),
            CountOfLetters = str.Count(char.IsLetter),
        };
        
        Console.WriteLine($"Длина: {stringInfo.Length} \nКол-во цифр: {stringInfo.CountOfDigits} \nКол-во букв: {stringInfo.CountOfLetters}");
    }
}