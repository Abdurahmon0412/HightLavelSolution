using Bogus;
using Lesson39_FakeDate;

public class Program
{
    public static void Main(string[] args)
    {
        int studentsIds = 0;
        Faker<Student> studentFaker = new Faker<Student>()
            .RuleFor(student => student.Id, id => studentsIds++)
            .RuleFor(student => student.FirstName, name => name.Person.FirstName)
            .RuleFor(student => student.Address, name => name.Address.FullAddress())
            .RuleFor(student => student.Description, description => description.Lorem.Paragraph(10));
        var students = studentFaker.Generate(50);

        Faker<Address> addressFaker = new Faker<Address>()
            .RuleFor(address => address.FullAddress, fullAddress => fullAddress.Address.FullAddress())
            .RuleFor(address => address.City, fullAddress => fullAddress.Address.City())
            .RuleFor(address => address.Country, fullAddress => fullAddress.Address.Country())
            .RuleFor(address => address.StreetSuffix, fullAddress => fullAddress.Address.StreetSuffix())
            .RuleFor(address => address.CountrySuffix, fullAddress => fullAddress.Address.City());

        var address = addressFaker.Generate(50);

        Faker faker = new Faker();
        faker.Address.City();
        Console.WriteLine();

    }
}
