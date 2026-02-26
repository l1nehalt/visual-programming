using pr_1.Enums;

namespace pr_1.Models;

public class Proposal
{
    public string Code {get; set;}
    
    public string Title {get; set;}
    
    public string Text {get; set;}
    
    public DateTime Date {get; set;}

    public StatusProposal Status { get; set; } = StatusProposal.Waiting;
    
    public void View() {}
    
    public void ViewStatus() {}
    
    public void Update() {}
    
    public void Delete() {}
    
    public void Archive() {}
    
    public void ViewApplicant() {}
}