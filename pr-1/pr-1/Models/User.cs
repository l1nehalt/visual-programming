using pr_1.Enums;

namespace pr_1.Models;

public class User
{
    public int Id { get; set; }
    
    public int DepartmentId { get; set; }
    
    public string Nickname { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }
    
    public Gender Gender { get; set; }
    
    public string Email { get; set; }
    
    public RoleUser Role { get; set; }
    
    public void Login() {}
    
    public void AddProposal() {}
    
    public void ViewProposal() {}
    
    public void ConfirmProposal() {}
    
    public void CreateReports() {} 
    
    public void ViewReports() {}
    
    public void UpdateDepartment() {}
    
}