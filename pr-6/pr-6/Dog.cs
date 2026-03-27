namespace pr_6;

public class Dog
{
    public int Age;
    
    public string Name;

    public Dog(int age, string name)
    {
        Age = age;
        Name = name;
    }
    
    public void ExecuteAndHandle(Action<Func<bool, int>, char, string> action)
    {
        Console.Write("Введите знак (+ или -): ");
        var inputSign = Convert.ToChar(Console.ReadLine());
        action(UpdateAge, inputSign, Name);
    }
    
    public void PrintResult(Func<bool, int> func, char sign, string name)
    {
        switch (sign)
        {
            case '+':
                Age = func(true);
                Console.WriteLine($"Собака: {name},\nВозраст: {Age} ({name} помолодел)");
                break;
            case '-':
                Age = func(false);
                Console.WriteLine($"Собака: {name},\nВозраст: {Age} ({name} постарел)");
                break;
        }
    }

    public int UpdateAge(bool value)
    {
        if (value) return Age += 3;
        return Age -= 3;
    }
}