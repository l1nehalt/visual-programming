using pr_2.Abstractions;

namespace pr_2.Polygons;

public class Parallelogram : Figure
{
    private double _angle;
    
    private double _sideA;
    
    private double _sideB;
    
    public Parallelogram(string name, string color, double sideA, double sideB, double angle) : base(name, color)
    {
        SideA = sideA;
        SideB = sideB;
        Angle = angle;
    }

    public double SideA
    {
        get => _sideA;
        set
        {
            if (value < 0) throw new Exception("Sides should be positive.");
            _sideA = value;
        }
    }
    
    public double SideB
    {
        get => _sideB;
        set
        {
            if (value <= 0) throw new Exception("Sides should be positive.");
            _sideB = value; 
        }
    }
    

    public double Angle
    {
        get => _angle;
        set
        {
            if (value <= 0 && value > 90) throw new Exception("Angle should be in range (0; 90)");
            _angle = value;
        }
    }

    public override double Perimeter => 2 * (SideA + SideB);


    public override double Area => SideA * SideB * Math.Sin(Angle * Math.PI / 180);
}