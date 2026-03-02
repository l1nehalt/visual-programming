using pr_3;

string str = "123abed";

var result = str.GetInfo();

Console.WriteLine($"Длина: {result.Length}\nЧисло цифр: {result.CountOfDigits}\nЧисло букв: {result.CountOfLetters}");