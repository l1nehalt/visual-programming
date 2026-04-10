namespace pr_7;

public class Item
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
}