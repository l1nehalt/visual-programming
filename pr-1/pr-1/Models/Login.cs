namespace pr_1.Models;

public class Login
{
    public string Username  { get; set; }
    
    public string Password { get; set; }
    
    public List<User> Users { get; set; }

    public bool Status() => true;
}