using lab_8;
using lab_8.BST;

Tree<int> intTree = new Tree<int>();
intTree.Insert(50);
intTree.Insert(30);
intTree.Insert(70);
intTree.Insert(20);
intTree.Insert(40);

var foundItem = intTree.Find(50);

Console.WriteLine(foundItem != null 
    ? $"Найдено: {foundItem.Data}" 
    : "Элемент не найден");

Console.WriteLine("Прямой обход:");

foreach (int num in intTree)
{
    Console.Write(num + " ");
}
Console.WriteLine();

Console.WriteLine("\nУдаление числа 30:");
intTree.Remove(30);
            
Console.WriteLine("Прямой обход после удаления:");
foreach (int num in intTree)
{
    Console.Write(num + " ");
}
Console.WriteLine("\n");


Tree<Item> itemTree = new Tree<Item>();
itemTree.Insert(new Item(1, "Shirt", "blue", 1500));
itemTree.Insert(new Item(5, "Jacket", "red", 3000));
itemTree.Insert(new Item(4, "Cap", "green", 1300));
itemTree.Insert(new Item(2, "Jeans", "black", 3200));

Console.WriteLine("Прямой обход объектов Item:");
foreach (Item item in itemTree)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nИщем элемент с артикулом 5");
var foundNode = itemTree.Find(new Item(5));

Console.WriteLine(foundNode != null 
    ? $"Найдено: {foundNode.Data}" 
    : "Элемент не найден.");
