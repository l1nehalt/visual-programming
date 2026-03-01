namespace pr_2.Quadrilaterals;

public class Triangle : RegularPolygon
{
    public Triangle(string name, string color, double sideLength) : base(name, color, 3, sideLength) {}
    
    public override double Perimeter => 3 * SideLength;

    public override double Area => (Math.Pow(SideLength, 2) * Math.Sqrt(3)) / 4;
}