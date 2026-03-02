namespace lab_2;

public static class GroupExtensions
{
    public static void GetStudents(this Group group)
    {
        foreach (var student in group.Students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }
}