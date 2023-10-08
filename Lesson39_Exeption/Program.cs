// See https://aka.ms/new-console-template for more information
using Lesson40_Exeption.Services;

Console.WriteLine("Hello, World!");

var accountService = new AccauntService();
try
{
    accountService.RegisterAsync("", "asa");
    //accountService.RegisterAsync("abdurahmonsadriddinov0412@gmail.com", "kello");
    //accountService.RegisterAsync("abdurahmonsadriddinov0412@gmail.com", "kello");
}
catch(ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch(InvalidOperationException ex) {Console.WriteLine(ex.Message);}
finally
{
    Console.WriteLine("The end");
}


