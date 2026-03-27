namespace pr_6;

public class Figure
{
    public int Side { get; set; }

    public Figure(int side)
    {
        Side = side;
    }
    
    public void UpdateSide(int value)
    {
        if (value > 0)
        {
            Side = value * 2;
        }
        else
        {
            Side = value - 10;
        }
    }
    
    public string PrintSignAndHandler(Action<int> action, bool condition, char sign)
    {
        Console.Write("Введите сторону: ");
        var input = Convert.ToInt32(Console.ReadLine());

        if (condition) action(input);

        sign = input >= 0 
            ? '+' 
            : '-';

        return sign.ToString();
    }
    
    public void Process(Func<Action<int>, bool, char, string> func)
    {
        string res = func(UpdateSide, true, 'f');
        Console.WriteLine($"Результат: {res}, Side = {Side}");
    }

}