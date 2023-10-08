using DependensyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependensyInjection.Services.Interfaces
{
    public interface IUserService
    {
        ValueTask<User> CreateAsync(User user);
    }
}
