using pr_2.Abstractions;

namespace pr_2.Ellipses;

public class Circle : Figure 
{
    public double Radius { get; set; }

    public Circle(string name, string color, double radius) : base(name, color)
    {
        Radius = radius;
    }

    public override double Perimeter => 2 * Math.PI * Radius;
    
    public override double Area => Math.PI * Radius * Radius;
}