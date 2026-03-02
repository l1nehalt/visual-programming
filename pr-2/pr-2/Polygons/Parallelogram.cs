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

    public override double Perimeter => SideA > 0 && SideB > 0 && Angle > 0
        ? 2 * (SideA + SideB)
        : throw new Exception("invalid parameters");


    public override double Area => SideA > 0 && SideB > 0 && Angle > 0
        ? SideA * SideB * Math.Sin(Angle * Math.PI / 180)
        : throw new Exception("invalid parameters");
}