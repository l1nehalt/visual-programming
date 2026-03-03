using System.Collections;

namespace lab_2;

public class Group : ICloneable
{
    public int GroupId { get; }

    public List<Student> Students { get; set; } = new List<Student>();

    public Group(int groupId)
    {
        GroupId = groupId;
    }
    
    public void Add(Student student)
    {
        if (Students.Any(s => s.Id == student.Id))
        {
            throw new Exception($"Студент с №{student.Id} уже существует");
        }
        
        List<Student> newStudents = new List<Student>();
        
        newStudents.Add(student);
        
        Students = newStudents;
    }

    public void Remove(int id)
    {
        if (!Students.Any(s => s.Id == id))
        {
            throw new Exception($"Студента по №{id} не существует");
        }

        Students = (List<Student>)Students.Where(s => s.Id != id);
    }
    
    public string this[int id]
    {
        get
        {
            var student = Students.First(s => s.Id == id);
            
            if (student == null)
            {
                throw new Exception($"Зачетка №{id} не найдена");
            }
            
            return student.GetInfo();
        }
    }

    public override string ToString()
    {
        var sortedStudents = Students.OrderBy(s => s.LastName);
        
        string result = $"Список группы №{GroupId}:\n";
        
        foreach (var st in sortedStudents)
        {
            result += "\n" + st.GetInfo() + "\n";
        }
        
        return result;
    }

    public object Clone()
    {
        var newGroup = new Group(GroupId);
        newGroup.Students = Students;
        return newGroup;
    }

    /*public object Clone()
    {
        var newGroup = new Group(GroupId);

        newGroup.Students = new List<Student>();
        
        Students.ForEach(s =>
        {
            Student student = new Student(
                s.FirstName, s.LastName, s.Patronymic,
                s.DateOfBirth, s.Adress, s.PhoneNumber,
                s.Id, s.Nationality, s.EducationForm
            );
            newGroup.Students.Add(student);
        });
        
        return newGroup;
    }*/
}