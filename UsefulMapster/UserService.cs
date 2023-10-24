using Mapster;
using UsefulMapster.DTOs;
using UsefulMapster.Entities;

namespace UsefulMapster;

public class UserService
{
    private IList<User> _users = new List<User>();

    public User Create(UserForCreation user)
    {
        var userExist = _users.FirstOrDefault(u => u.Email == user.Email);
        if (userExist != null)
        {

            return userExist;
        }
        Console.WriteLine("hello worlds!");
        var newUser = user.Adapt<User>();

        newUser.CreatedAt = DateTime.Now;
        newUser.UpdatedAt = DateTime.Now;

        _users.Add(newUser);
        return newUser;
    }
}