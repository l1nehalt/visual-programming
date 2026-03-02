namespace pr_2.Ellipses;

public class Ring : Circle
{
    private double _innerRadius;

    public Ring(string name, string color, double outerRadius, double innerRadius) : base(name, color, outerRadius)
    {
        InnerRadius = innerRadius;
    }

    public double InnerRadius
    {
        get => _innerRadius;
        set
        {
            if (value <= 0) throw new Exception("Radius should be positive.");
            if (value >= Radius) throw new Exception("Inner radius cannot be greater or equal to outer radius.");
            _innerRadius = value;
        }
    }
    
    public new double Radius
    {
        get => radius;
        set
        {
            if (radius <= 0) throw new Exception("Radius should be positive.");
            if (_innerRadius > radius) throw new  Exception("Inner radius cannot be greater or equal to outer radius.");
            radius = value;
        }
    }

    public override double Perimeter => Math.PI * (Radius + InnerRadius);

    public override double Area => Math.PI * (Math.Pow(Radius, 2) - Math.Pow(InnerRadius, 2));
}