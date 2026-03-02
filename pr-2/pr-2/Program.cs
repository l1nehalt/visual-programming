using pr_2.Abstractions;
using pr_2.Ellipses;
using pr_2.Polygons;
using pr_2.Quadrilaterals;

Parallelogram par = new Parallelogram("Параллелограмм", "Синий", 30, 50, 60);
Ring ring = new Ring("Кольцо", "Черный", 60, 50);
Rectangle rect = new Rectangle("Ректангл", "Синий", 30, 50);
Rhombus rhomb = new Rhombus("Ромбус", "Синий", 30, 50);
Square square = new Square("Квадрат", "Красный", 40);
List<Figure> figures =
[
    rect,
    ring,
    rhomb,
    par,
    square
];

figures.ForEach(figure => Console.WriteLine(figure.ToString()));
