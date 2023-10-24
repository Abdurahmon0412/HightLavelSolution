namespace Mapster.Console.DTOs;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public string UseName { get; set; }
    public DateTime CreatedAt { get; set; }
}
