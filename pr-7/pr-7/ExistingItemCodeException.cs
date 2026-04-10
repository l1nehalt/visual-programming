using System.Runtime.Serialization;

namespace pr_7;

[Serializable]
public class ExistingItemCodeException : Exception, ISerializable
{
    public Item? Item;

    public ExistingItemCodeException()
    {
    }

    public ExistingItemCodeException(string message) : base(message)
    {
    }

    public ExistingItemCodeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ExistingItemCodeException(Item item) : base($"Item with the article number {item.Article} already exists")
    {
        Item = item;
        Data.Add("Article", item.Article);
        Data.Add("Name", item.Name);
        Data.Add("Color", item.Color);
        Data.Add("Price", item.Price);
    }

    protected ExistingItemCodeException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Item = (Item)info.GetValue("Item", typeof(Item));
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue("Item", Item, typeof(Item));
    }
}