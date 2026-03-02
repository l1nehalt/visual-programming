namespace pr_2.Abstractions;

public abstract class Figure
{
    protected Figure(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; }

    public string Color { get; }

    public abstract double Perimeter { get; }
    
    public abstract double Area { get; }

    public override string ToString()
    {
        return $" Фигура: {Name} \n Цвет: {Color} \n Периметр: {Perimeter} \n Площадь: {Area}\n";
    }
}