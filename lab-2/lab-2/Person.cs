namespace lab_2;

public class Person
{
    public string FirstName { get; }

    public string LastName { get; }
    
    public string? Patronymic  { get; }
    
    public DateTime DateOfBirth { get; }
    
    public string Adress { get; }
    
    public string PhoneNumber { get; }

    public Person(string firstName,  string lastName, string patronymic, DateTime dateOfBirth, string adress, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        DateOfBirth = dateOfBirth;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Person p)
        {
            if (FirstName == p.FirstName && LastName == p.LastName && Patronymic == p.Patronymic && DateOfBirth == p.DateOfBirth && Adress == p.Adress && PhoneNumber == p.PhoneNumber)
            {
                return true;
            }
           
        }
        return false;
    }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName} {Patronymic}";
    }
    
    public virtual string GetInfo()
    {
        return $"{FirstName} {LastName} {Patronymic} \n {DateOfBirth} \n {Adress} \n {PhoneNumber}";
    }
}