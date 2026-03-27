using pr_6;

/*Execute(PrintResult);

void Execute(Action<Func<bool, int>, char, string> action)
{
    action(x => x ? 1 : -1, 'с', "string");
}

void PrintResult(Func<bool, int> func, char c, string str)
{
    if (func(true) > 0) 
        Console.WriteLine(c);
    else 
        Console.WriteLine(str);
}*/

Dog dog = new Dog(10, "Бублик");

dog.ExecuteAndHandle(dog.PrintResult);


//

Figure figure = new Figure(5);

figure.Process(figure.PrintSignAndHandler);






