namespace pr_2.Polygons;

public class Rhombus : Parallelogram
{
    public Rhombus(string name, string color, double side, double angle) : base(name, color, side, side, angle) {}

    public override double Perimeter => 4 * SideA;
    
    public override double Area => SideA * SideA * Math.Sin(Angle * Math.PI / 180);
}