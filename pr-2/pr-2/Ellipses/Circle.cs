using pr_2.Abstractions;

namespace pr_2.Ellipses;

public class Circle : Figure
{
    protected double radius;

    public Circle(string name, string color, double radius) : base(name, color)
    {
        Radius = radius;
    }

    public double Radius
    {
        get => radius;
        set => radius = value > 0
            ? value
            : throw new Exception("Radius should be positive.");
    }

    public override double Perimeter => 2 * Math.PI * Radius;

    public override double Area => Math.PI * Radius * Radius;
}