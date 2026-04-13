namespace lab_8;

public class Item : IComparable<Item>
{
    public int Article;

    public string Color;

    public string Name;

    public int Price;

    public Item(int article, string name, string color, int price)
    {
        Article = article;
        Name = name;
        Color = color;
        Price = price;
    }

    public Item(int article)
    {
        Article = article;
        Name = string.Empty;
        Color = string.Empty;
        Price = 0;
    }

    public int CompareTo(Item? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        
        int comparison = Article.CompareTo(other.Article);
        
        if (comparison == 0) return 0; 

        return comparison;
    }
    
    public override string ToString()
    {
        return $"Артикль: {Article} Название: {Name} Цвет: {Color} Цена: {Price}";
    }
}