namespace lab_2;

public class Group
{
    public int GroupId { get; }

    public Student[] Students { get; set; } = Array.Empty<Student>();

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
        
        Student[] newStudents = new Student[Students.Length + 1];

        for (int i = 0; i < Students.Length; i++)
        {
            newStudents[i] = Students[i];
        }
        
        newStudents[newStudents.Length - 1] = student;
        
        Students = newStudents;
    }

    public void Remove(int id)
    {
        if (!Students.Any(s => s.Id == id))
        {
            throw new Exception($"Студента по №{id} не существует");
        }

        Students = Students.Where(s => s.Id != id).ToArray();
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
}