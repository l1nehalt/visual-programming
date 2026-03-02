namespace pr_2.Abstractions;

public abstract class Figure
{
    public string Name { get; }
    
    public string Color { get; }
    
    public abstract double Perimeter { get; }
    
    public abstract double Area { get; }

    protected Figure(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public override string ToString()
    {
        return $" Фигура: {Name} \n Цвет: {Color} \n Периметр: {Perimeter} \n Площадь: {Area}";
    }
}