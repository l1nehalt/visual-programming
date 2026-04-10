namespace pr_7;

public class Shop
{
    private readonly List<Item> _items = [];

    public void AddItem(Item item)
    {
        if (_items.Any(i => i.Article == item.Article)) throw new ExistingItemCodeException(item);
        _items.Add(item);
    }
}