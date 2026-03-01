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

    public override double Perimeter => NumberOfSides * SideLength;

    public override double Area => (NumberOfSides * Math.Pow(SideLength, 2)) / (4 * Math.Tan(Math.PI / NumberOfSides));
}