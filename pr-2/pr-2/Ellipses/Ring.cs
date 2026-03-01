namespace pr_2.Ellipses;

public class Ring : Circle
{
    public double InnerRadius { get; set; }
    
    public Ring(string name, string color, double outerRadius, double innerRadius) : base(name, color, outerRadius)
    {
        InnerRadius = innerRadius;
    }

    public override double Perimeter => 2 * Math.PI * (Radius + InnerRadius);

    public override double Area => Math.PI * (Math.Pow(Radius, 2) - Math.Pow(InnerRadius, 2));
}