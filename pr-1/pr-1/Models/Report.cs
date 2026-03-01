namespace pr_1.Models;

public class Report
{
    public int Code {get; set;}
    
    public DateTime Date {get; set;}
    
    public User User {get; set;}
    
    public Proposal Proposal {get; set;}

    public void View() {}
    
    public void Create() {}
}