using pr_5.Figures;
using pr_5.Generics;

var rectangle = new Figure("Rectangle", 20);
var circle = new Circle("Circle", 15);
var square = new Square("Square", 33);

var list1 = new GenericList<string>();
list1.Add("12");
list1.Add("90");
list1.Add("0");
list1.Print();
Console.WriteLine("\n");

list1.BubbleSort();
list1.Print();
Console.WriteLine("\n");

var list2 = new GenericList<Figure>();
list2.Add(rectangle);
list2.Add(square);
list2.Add(circle);

list2.Print();

list2.BubbleSort();

Console.WriteLine("\n");
list2.Print();
