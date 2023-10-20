namespace FhotoGram.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string passwordHash { get; set; }
    public string ProfileImagePath { get; set; }
}