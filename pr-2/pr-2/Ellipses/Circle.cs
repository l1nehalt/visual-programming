using pr_2.Abstractions;

namespace pr_2.Ellipses;

public class Circle : Figure 
{
    public double Radius { get; set; }

    public Circle(string name, string color, double radius) : base(name, color)
    {
        Radius = radius;
    }

    public override double Perimeter => Radius > 0
        ? 2 * Math.PI * Radius
        : throw new Exception("invalid parameters");

    public override double Area => Radius > 0
        ? Math.PI * Radius * Radius
        : throw new Exception("invalid parameters");
}