using lab_2;

var student1 = new Student(
    "Иван", 
    "Иванов", 
    "Иванович", 
    new DateTime(2003, 5, 15),
    "ул. Пушкина, д. 10", 
    "+79001234567", 
    1, 
    "Русский", 
    EducationForm.Budget 
);

var student2 = new Student(
    "Петр", 
    "Сергеев", 
    "Иванович", 
    new DateTime(2005, 7, 15),
    "ул. Пушкина, д. 15", 
    "+79001238767", 
    2, 
    "Серб", 
    EducationForm.Commercial
);

Group group340 = new Group(340);

group340.Add(student1);
group340.Add(student2);

Console.WriteLine("Метод ToString() класса Group");
Console.WriteLine(group340.ToString());

Console.WriteLine("Переопределние индексатора для класса Group");
Console.WriteLine(group340[1]);

Console.WriteLine("Метод GetInfo() у класса Student");
Console.WriteLine(student1.GetInfo());

Console.WriteLine("Метод Equals() у класса Student");
Console.WriteLine(student2.Equals(student1));

Console.WriteLine("Переопределние операций == и != ");
Console.WriteLine(student1 != student2);



