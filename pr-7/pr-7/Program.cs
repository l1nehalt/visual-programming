using System.Collections;
using pr_7;

var shop = new Shop();

var shirt = new Item(1, "Shirt", "blue", 1500);
var jacket = new Item(1, "Jacket", "red", 3000);
var cap = new Item(2, "Cap", "green", 1300);
var hap = new Item(2, "Hap", "white", 1000);
var jeans = new Item(3, "Jeans", "black", 3200);

List<Item> items = new List<Item> { shirt, jacket, cap, hap, jeans };

foreach (var item in items)
{
    try
    {
        shop.AddItem(item);
        Console.WriteLine($"{item.Name} added successfully");
    }
    catch (ExistingItemCodeException e)
    {
        Console.WriteLine(e.Message);
        foreach (DictionaryEntry d in e.Data)
        {
            Console.WriteLine(d.Key + ": " + d.Value);
        }
    }
}
