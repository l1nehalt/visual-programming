namespace pr_2.Quadrilaterals;

public class Square : RegularPolygon
{
    public Square(string name, string color, double sideLength) : base(name, color, 4, sideLength) {}
    
    public override double Perimeter => SideLength > 0
        ? 4 * SideLength
        : throw new Exception("invalid parameters");

    public override double Area => SideLength > 0
        ? SideLength * SideLength
        : throw new Exception("invalid parameters");
}