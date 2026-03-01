namespace pr_2.Quadrilaterals;

public class Square : RegularPolygon
{
    public Square(string name, string color, double sideLength) : base(name, color, 4, sideLength) {}
    
    public override double Perimeter => 4 * SideLength;

    public override double Area => SideLength * SideLength;
}