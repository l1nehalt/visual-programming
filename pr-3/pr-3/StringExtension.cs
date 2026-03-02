namespace pr_3;

public static class StringExtension
{
    public static StringInfo GetInfo(this string str)
    {
        var stringInfo = new StringInfo
        {
            Length = str.Length,
            CountOfDigits = str.Count(char.IsDigit),
            CountOfLetters = str.Count(char.IsLetter),
        };
        
        return stringInfo;
    }
}