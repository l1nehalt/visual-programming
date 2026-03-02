using pr_2.Abstractions;

namespace pr_2.Quadrilaterals;

public class RegularPolygon : Figure
{
    public int NumberOfSides { get; set; }
    
    public double SideLength { get; set; }
    
    public RegularPolygon(string name, string color, int numberOfSides, double sideLength) : base(name, color)
    {
        NumberOfSides = numberOfSides;
        SideLength = sideLength;
    }

    public override double Perimeter => NumberOfSides > 0 && SideLength > 0
        ? NumberOfSides * SideLength
        : throw new Exception("invalid parameters");

    public override double Area => NumberOfSides > 0 && SideLength > 0
        ? (NumberOfSides * Math.Pow(SideLength, 2)) / (4 * Math.Tan(Math.PI / NumberOfSides))
        : throw new Exception("invalid parameters");
}