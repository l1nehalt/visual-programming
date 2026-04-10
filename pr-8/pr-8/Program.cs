using pr_8;

List<Item> items = new List<Item>
{
    new Item { Id = 1, Name = "Monitor", Color = "Black", Price = 15000, Vendor = "Dell", ProductionDate = new DateTime(2023, 5, 10) },
    new Item { Id = 2, Name = "Mouse", Color = "White", Price = 2000, Vendor = "Logitech", ProductionDate = new DateTime(2024, 1, 15) },
    new Item { Id = 3, Name = "Keyboard", Color = "Black", Price = 4500, Vendor = "Logitech", ProductionDate = new DateTime(2024, 3, 20) },
    new Item { Id = 4, Name = "Laptop", Color = "Silver", Price = 85000, Vendor = "Apple", ProductionDate = new DateTime(2023, 11, 5) },
    new Item { Id = 5, Name = "Monitor", Color = "Gray", Price = 12000, Vendor = "Samsung", ProductionDate = new DateTime(2024, 2, 1) },
    new Item { Id = 6, Name = "Tablet", Color = "Blue", Price = 30000, Vendor = "Samsung", ProductionDate = new DateTime(2022, 12, 12) },
    new Item { Id = 7, Name = "Printer", Color = "White", Price = 18000, Vendor = "HP", ProductionDate = new DateTime(2024, 4, 5) },
    new Item { Id = 8, Name = "Mouse", Color = "Red", Price = 1500, Vendor = "HP", ProductionDate = new DateTime(2023, 8, 25) }
};

int currentYear = DateTime.Now.Year;

// a
var a1 = items
    .OrderBy(i => i.Vendor)
    .ThenBy(i => i.Name);

var a2 = 
    from i in items 
    orderby i.Vendor, i.Name 
    select i;

// b
var b1 = items
    .Where(i => i.Vendor == "Logitech");
var b2 = 
    from i in items 
    where i.Vendor == "Logitech" 
    select i;

// c
var c1 = items
    .OrderByDescending(i => i.Price)
    .Take(3);
var c2 = (
    from i in items 
    orderby i.Price 
    descending select i
    ).Take(3);

// d
var d1 = items
    .Where(i => i.ProductionDate.Year == currentYear);
var d2 = 
    from i in items 
    where i.ProductionDate.Year == currentYear 
    select i;

// e
var e1 = items
    .OrderByDescending(i => i.ProductionDate)
    .FirstOrDefault();
var e2 = (
    from i in items 
    orderby i.ProductionDate 
    descending select i
    ).FirstOrDefault();

// f
string searchName = "Monitor";
var f1 = items
    .Where(i => i.Name == searchName)
    .Select(i => i.Vendor)
    .Distinct()
    .Count();
var f2 = (
    from i in items 
    where i.Name == searchName 
    select i.Vendor
    ).Distinct().Count();

// g
var g1 = items
    .GroupBy(i => i.Vendor)
    .Where(g => g.All(i => i.Price > 10000))
    .Select(g => g.Key);
var g2 = 
    from i in items 
    group i by i.Vendor into g 
    where g.All(x => x.Price > 10000) 
    select g.Key;

// h
double avgPrice = items
    .Average(i => i.Price);
var h1 = items
    .Where(i => i.ProductionDate.Year != currentYear || i.Price < avgPrice);
var h2 = 
    from i in items 
    where i.ProductionDate.Year != currentYear || i.Price < avgPrice 
    select i;

// i
var i1 = items
    .Select(i => $"{i.Id} {i.Name} {i.Color}");
var i2 = 
    from i in items 
    select $"{i.Id} {i.Name} {i.Color}";

// j
var j1 = items
    .GroupBy(i => i.Vendor)
    .Select(g => new { Vendor = g.Key, MinPrice = g.Min(i => i.Price) });
var j2 = 
    from i in items 
    group i by i.Vendor into g 
    select new { Vendor = g.Key, MinPrice = g.Min(x => x.Price) };