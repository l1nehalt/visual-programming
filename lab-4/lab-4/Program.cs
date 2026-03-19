/*using lab_4;

DynamicArray<int> numbers = new DynamicArray<int>();
        
Console.WriteLine($"Начальная емкость: {numbers.Capacity}");
Console.WriteLine($"Начальное количество: {numbers.Count}");
        
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
        
Console.WriteLine("\nПосле добавления трех элементов:");
Console.WriteLine($"Количество: {numbers.Count}");
Console.WriteLine($"Емкость: {numbers.Capacity}");
        
numbers.Insert(15, 1);
        
Console.WriteLine("\nПосле вставки 15 на позицию 1:");
foreach (var num in numbers)
{
    Console.Write(num + " ");
}
        
numbers.RemoveAt(2);
        
Console.WriteLine("\n\nПосле удаления элемента с позиции 2:");
foreach (var num in numbers)
{
    Console.Write(num + " ");
}
        
List<int> moreNumbers = new List<int> { 40, 50, 60 };
numbers.Add(moreNumbers);
        
Console.WriteLine("\n\nПосле добавления коллекции:");
foreach (var num in numbers)
{
    Console.Write(num + " ");
}
        
Console.WriteLine($"\nКоличество: {numbers.Count}");
Console.WriteLine($"Емкость: {numbers.Capacity}");
        
Console.WriteLine("\nИтерация с помощью foreach:");
foreach (var num in numbers)
{
    Console.Write(num + " ");
}
        
Console.WriteLine("\n\nИтерация с помощью явного перечислителя:");
using (var enumerator = numbers.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        Console.Write(enumerator.Current + " ");
    }
}
        
Console.WriteLine();*/


using lab_4;

var array = new DynamicArray<int> {5, 3, 1, 7, 10};

var res = array.Filter(x => x > 5);

foreach (var item in res)
{
    Console.Write(item + " ");
}

Console.WriteLine();

array.Sort((a, b) => a - b);

foreach (var item in array)
{
    Console.Write(item + " ");
}