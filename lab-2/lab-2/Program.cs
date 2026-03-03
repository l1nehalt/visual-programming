using lab_2;

var student = new Student(
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

group340.Add(student);

Group group341 = (Group)group340.Clone();

student.DateOfBirth = new DateTime(2006, 7, 15);

group341.GetStudents();

/*
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
*/



