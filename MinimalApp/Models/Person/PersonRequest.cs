namespace MinimalApp.Models.Person;

public record PersonRequest(
    string FirstName, 
    string LastName, 
    DateTime DateOfBirth, 
    string Email, 
    string Password, 
    string DocumentNumber, // CPF
    string Phone
);