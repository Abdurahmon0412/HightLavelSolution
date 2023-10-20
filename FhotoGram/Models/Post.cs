namespace FhotoGram.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public Guid UserId { get; set; }
}