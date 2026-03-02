namespace pr_2.Polygons;

public class Rhombus : Parallelogram
{
    public Rhombus(string name, string color, double side, double angle) : base(name, color, side, side, angle) {}

    public override double Perimeter => SideA > 0 && SideB > 0 && Angle > 0
        ? 4 * SideA
        : throw new Exception("invalid parameters");
    
    public override double Area => SideA > 0 && SideB > 0 && Angle > 0
        ? SideA * SideA * Math.Sin(Angle * Math.PI / 180)
        : throw new Exception("invalid parameters");
}