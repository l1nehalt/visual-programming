namespace pr_7;

public class ExistingItemCodeException : Exception
{
    public Item Item;

    public ExistingItemCodeException(Item item) : base($"Item with the article number {item.Article} already exists")
    {
        Item = item;
        Data.Add("Article", item.Article);
        Data.Add("Name", item.Name);
        Data.Add("Color", item.Color);
        Data.Add("Price", item.Price);
    }
}