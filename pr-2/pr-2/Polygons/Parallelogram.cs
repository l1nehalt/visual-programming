using pr_2.Abstractions;

namespace pr_2.Polygons;

public class Parallelogram : Figure
{
    public double SideA { get; set; }
    
    public double SideB { get; set; }
    
    public double Angle { get; set; }

    public Parallelogram(string name, string color, double sideA, double sideB, double angle) : base(name, color)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }
    
    public override double Perimeter => 2 * (SideA + SideB);
    
    public override double Area => SideA * SideB * Math.Sin(Angle * Math.PI / 180);
}