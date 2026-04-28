using lab_9;

User user1 = new User { Age = 20, Name = "John Doe", Email = "waeawriar@gmail.com" };
User user2 = new User { Age = 15, Name = "Peter Smith", Email = "fregehrg@gmail.com" };

List<User> users = [user1, user2];
Console.WriteLine();

Console.WriteLine("Результат метода SelectProperty:");
var result1 = users.SelectProperty(x => x.Email).ToList();
result1.ForEach(Console.WriteLine);
Console.WriteLine();

Console.WriteLine("Результат метода Filter:");
var result2 = users.Filter(user => user.Age < 20).ToList();
result2.ForEach(x => Console.WriteLine(x.Name));
Console.WriteLine();

Console.WriteLine("Результат метода FindByLetter:");
var result3 = users.FindByLetter(x => x.Name, 'J').ToList();
result3.ForEach(x => Console.WriteLine(x.Name));
Console.WriteLine();

Console.WriteLine("Результат метода ExecuteAction:");
var result4 = users.ExecuteAction(x => x.Age -= 3).ToList();
result4.ForEach(x => Console.WriteLine(x.Age));
Console.WriteLine();

Console.WriteLine("Результат метода TakeByRange:");
var result5 = users.TakeByRange(x => x.Age, 10, 16).ToList();
result5.ForEach(x => Console.WriteLine(x.Name));


