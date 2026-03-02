using pr_2.Abstractions;

namespace pr_2.Quadrilaterals;

public class RegularPolygon : Figure
{
    private int _numberOfSides;
    
    private double _sideLength;
    
    public RegularPolygon(string name, string color, int numberOfSides, double sideLength) : base(name, color)
    {
        NumberOfSides = numberOfSides;
        SideLength = sideLength;
    }

    public int NumberOfSides
    {
        get => _numberOfSides;
        set
        {
            if (value <= 0) throw new Exception("Number of sides should be greater than 0");
            _numberOfSides = value;
        }
    }

    public double SideLength
    {
        get => _sideLength;
        set
        {
            if (value <= 0) throw new Exception("Side length should be greater than 0");
            _sideLength = value;
        }
    }

    public override double Perimeter => NumberOfSides * SideLength;

    public override double Area => NumberOfSides * Math.Pow(SideLength, 2) / (4 * Math.Tan(Math.PI / NumberOfSides));
}