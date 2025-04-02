namespace MinimalApp.Models;

public class AdminModel
{
    public AdminModel(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void Change(string name, string email, string password)
    {
        Name = name;
        Email = name;
        Password = password;
    }
}