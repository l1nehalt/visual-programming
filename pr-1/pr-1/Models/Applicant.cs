using pr_1.Enums;

namespace pr_1.Models;

public class Applicant
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Job { get; set; }
    
    public string Address { get; set; }
    
    public Gender Gender { get; set; }
    
    public char TelephoneNumber { get; set; }
    
    public Proposal Proposal { get; set; }
    
    public void Insert() {}
    
    public void Update() {}
    
    public void Delete() {}
}