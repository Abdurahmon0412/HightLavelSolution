using DependensyInjection.Models;
using DependensyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependensyInjection.Services
{
    public class UserService : IUserService
    {
        public ValueTask<User> CreateAsync(User user)
        {
            return new(user);
        }
    }
}
