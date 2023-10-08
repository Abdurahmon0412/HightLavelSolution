using DependensyInjection.Models;
using DependensyInjection.Services;
using DependensyInjection.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

//using Di.Console.Models.Accounts;
//using Di.Console.Services;
//using Di.Console.Services.Interfaces;
//using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

services
    .AddSingleton<IAccountService, AccountService>()
    .AddSingleton<IUserService, UserService>()
    .AddScoped<IEmailSenderServices, EmailSenderService>();

var provider = services.BuildServiceProvider();

var accountService = provider.GetRequiredService<IAccountService>();

var result = await accountService.RegisterAsync(new RegisterDetails()
{
    EamilAddress = "abdurahmonsadriddinov0412@gmail.com",
    Password = "Testtest_1"
});

Console.WriteLine(result);