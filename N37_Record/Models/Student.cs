using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_Record.Models
{
    public record Student(string FirstName, string LastName, int Age) : Person(FirstName, LastName);
}
