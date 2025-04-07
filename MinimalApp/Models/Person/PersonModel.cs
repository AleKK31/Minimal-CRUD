namespace MinimalApp.Models.Person;

public class PersonModel
{
    public PersonModel(
        string firstName, 
        string lastName, 
        DateTime dateOfBirth, 
        string email, 
        string password, 
        string documentNumber, // CPF
        string phone
    )
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth; 
        Email = email;
        Password = password;
        DocumentNumber = documentNumber;
        Phone = phone;
    }
    
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string DocumentNumber { get; set; } // CPF
    public string Phone { get; set; }
    
    public void Change(
        string firstName, 
        string lastName,
        DateTime dateOfBirth,
        string email, 
        string password, 
        string documentNumber, 
        string phone
    )
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Password = password;
        DocumentNumber = documentNumber;
        Phone = phone;
    }
}