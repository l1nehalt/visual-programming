var path1 = @"C:\temp\K1";
var path2 = @"C:\temp\K2";

var dir1 = Directory.CreateDirectory(path1);
var dir2 = Directory.CreateDirectory(path2);

if (dir1.Exists && dir2.Exists) Console.WriteLine("Папки K1 и K2 по пути созданы");

var content1 = "Этот текст записан в файле t1.txt";
var content2 = "Этот текст записан в файле t2.txt";

var file1 = @"C:\temp\K1\t1.txt";
var file2 = @"C:\temp\K1\t2.txt";
var file3 = @"C:\temp\K2\t3.txt";

File.WriteAllText(file1, content1);
Console.WriteLine("Файл t1.txt создан и текст записан");

File.WriteAllText(file2, content2);
Console.WriteLine("Файл t2.txt создан и текст записан");

File.Copy(file1, file3, true);
var content3 = File.ReadAllText(file2);
File.AppendAllText(file3, "\n" + content3);
Console.WriteLine("Содержимое t1.txt и t2.txt успешно перезаписалось в t3.txt");

List<string> files = [file1, file2, file3];

foreach (var file in files)
    if (File.Exists(file))
    {
        var fileInfo = new FileInfo(file);

        Console.WriteLine(
            $"Название: {fileInfo.Name}; Размер: {fileInfo.Length} байт; Время создания: {fileInfo.CreationTime}");
    }
    else
    {
        Console.WriteLine("Не удалось найти файл");
    }

if (File.Exists(file2))
{
    if (File.Exists(@"C:\temp\K2\t2.txt")) File.Delete(@"C:\temp\K2\t2.txt");

    File.Move(file2, @"C:\temp\K2\t2.txt");

    Console.WriteLine("Файл t2.txt перенесен в папку K2");
}
else
{
    Console.WriteLine("Исходный файл t2.txt не найден");
}


if (File.Exists(file1))
{
    if (File.Exists(@"C:\temp\K2\t1.txt")) File.Delete(@"C:\temp\K2\t1.txt");

    File.Copy(file1, @"C:\temp\K2\t1.txt");

    Console.WriteLine("Файл t1.txt скопирован в папку K2");
}
else
{
    Console.WriteLine("Исходный файл t1.txt не найден");
}


var path3 = @"C:\temp\All";

if (dir2.Exists)
{
    if (Directory.Exists(path3)) Directory.Delete(path3, true);

    Directory.Move(path2, path3);
    Console.WriteLine("Папка K2 переименована в All");
}

if (Directory.Exists(path1))
{
    Directory.Delete(path1, true);
    Console.WriteLine("Папка K1 удалена");
}

if (Directory.Exists(path3))
{
    var allFiles = Directory.GetFiles(path3).ToList();

    if (allFiles.Count == 0) Console.WriteLine("Папка пуста");

    foreach (var file in allFiles)
    {
        var fileInfo = new FileInfo(file);

        Console.WriteLine(
            $"Название: {fileInfo.Name}; Размер: {fileInfo.Length} байт; Время создания: {fileInfo.CreationTime}");
    }
}
else
{
    Console.WriteLine("Папка All не найдена.");
}