using GenericDelegate.Extentions;
using GenericDelegate.Models;

#region
List<Topics> topicsA = new List<Topics>()
{
    new Topics("It", 1),
    new Topics("Business", 2),
    new Topics("Education", 3),
    new Topics("Logistika", 4)
};

List<Topics> topicsB = new List<Topics>()
{
    new Topics("It", 1),
    new Topics("Business", 2),
    new Topics("Education", 3),
    new Topics("Ecologiya", 4)
};



var postA = new Post()
{
    Id = Guid.NewGuid(),
    Title = "this is post1 title",
    Description = "Description",
    Topics = topicsA
};

var postB = new Post()
{
    Id = Guid.NewGuid(),
    Title = "this is post2 title",
    Description = "Description",
    Topics = topicsB
};
#endregion

var intersectedPosts = postA.Topics.ZipIntersectBy(postB.Topics, topic => topic.Id);

foreach (var (previus,updatePosts) in intersectedPosts)
{
    Console.WriteLine($"{previus.Name}");

    Console.WriteLine($"{updatePosts.Name}");
}

