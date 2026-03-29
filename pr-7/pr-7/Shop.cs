namespace pr_7;

public class Shop
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if (items.Any(i => i.Article == item.Article))
        {
            throw new ExistingItemCodeException(item);
        }
        items.Add(item);
    }
}