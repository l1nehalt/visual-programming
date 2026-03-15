namespace pr_5.Figures;

public class Figure : IComparable<Figure>
{
    public double Area { get; set; }
    
    public string Name { get; set; }
    
    public Figure(string name, double area)
    {
        Name = name;
        Area = area;
    }
    
    public int CompareTo(Figure? other)
    {
        return other == null 
            ? 1 
            : Area.CompareTo(other.Area);
    }
    
    public override string ToString()
    {
        return $"{Name} Площадь: {Area}";
    }
}