namespace pr_2.Polygons;

public class Rectangle : Parallelogram
{
    public Rectangle(string name, string color, double sideA, double sideB) : base(name, color, sideA, sideB, 90) {}

    public override double Perimeter => SideA > 0 && SideB > 0
        ? 2 * SideA + 2 * SideB
        : throw new Exception("invalid parameters");

    public override double Area => SideA > 0 && SideB > 0 
        ? SideA * SideB 
        : throw new Exception("invalid parameters");
}