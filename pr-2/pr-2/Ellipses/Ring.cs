namespace pr_2.Ellipses;

public class Ring : Circle
{
    public double InnerRadius { get; set; }
    
    public Ring(string name, string color, double outerRadius, double innerRadius) : base(name, color, outerRadius)
    {
        InnerRadius = innerRadius;
    }

    public override double Perimeter => InnerRadius > 0
        ? Math.PI * (Radius + InnerRadius)
        : throw new Exception("invalid parameters");

    public override double Area => InnerRadius > 0
        ? Math.PI * (Math.Pow(Radius, 2) - Math.Pow(InnerRadius, 2))
        : throw new Exception("invalid parameters");
}