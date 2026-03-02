namespace pr_2.Quadrilaterals;

public class Triangle : RegularPolygon
{
    public Triangle(string name, string color, double sideLength) : base(name, color, 3, sideLength) {}
    
    public override double Perimeter => SideLength > 0
       ? 3 * SideLength
       : throw new Exception("invalid parameters");

    public override double Area => SideLength > 0
        ? (Math.Pow(SideLength, 2) * Math.Sqrt(3)) / 4
        : throw new Exception("invalid parameters");
}