using pr_2.Abstractions;
using pr_2.Polygons;

Figure par = new Parallelogram("Параллелограмм", "Синий", 30, 50, 60);
Figure rect = new Rectangle("Ректангл", "Синий", 30, 50);
Figure rhomb = new Rhombus("Ромбус", "Синий", 30, 50);
List<Figure> figures = [
    rect,
    rhomb,
    par
];

figures.ForEach(figure => Console.WriteLine(figure.ToString()));
