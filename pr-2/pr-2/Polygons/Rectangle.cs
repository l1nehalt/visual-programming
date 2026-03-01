namespace pr_2.Polygons;

public class Rectangle : Parallelogram
{
    public Rectangle(string name, string color, double sideA, double sideB) : base(name, color, sideA, sideB, 90) {}

    public override double Perimeter => 2 * SideA + 2 * SideB;
    
    public override double Area => SideA * SideB;
}