using N37_Record.Models;

Person person = new Student("Firdavs", "Davlatov", 15);
int grade = ((Student)person).Age;
//person.Deconstruct(out string firstName, out string lastName);
(string firstName, string lastName) = person;
Console.WriteLine(firstName + "   " + lastName);