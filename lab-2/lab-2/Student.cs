namespace lab_2;

public class Student : Person
{
    public int Id { get; }
    
    public string Nationality { get; }
    
    public EducationForm EducationForm { get; }

    public Student(string firstName,  string lastName, string patronymic, 
        DateTime dateOfBirth, string adress, string phoneNumber, int id, string nationality, EducationForm educationForm) 
        : base(firstName,  lastName, patronymic, dateOfBirth, adress, phoneNumber) 
    {
        Id = id;
        Nationality = nationality;
        EducationForm = educationForm;
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()} \n {Id} \n {Nationality} \n {EducationForm} ";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Student student)
        {
            if (Id == student.Id && Nationality == student.Nationality && EducationForm == student.EducationForm && base.Equals(obj))
            {
                return true;
            }
        }
        
        return false;
    }

    public static bool operator ==(Student student1, Student student2)
    {
        if (student1.Equals(student2))
        {
            return true;
        }
        
        return false;
    }
    
    public static bool operator !=(Student student1, Student student2)
    {
        if (!student1.Equals(student2))
        {
            return true;
        }
        
        return false;
    }
    
}