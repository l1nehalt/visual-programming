namespace pr_5.Figures;

public class Circle : Figure
{
    public Circle(string name, double radius) : base(name, Math.PI * radius * radius) { }
}