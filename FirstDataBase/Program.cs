

using FirstDataBase.Domain.Entities;
using FirstDataBase.Persistance.DataContext;
using Microsoft.Extensions.DependencyInjection;
using System;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>();

var serviceProvider = services.BuildServiceProvider();

var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();

if (!appDbContext.Authors.Any())
{
    appDbContext.Authors.AddRange(new Author
    {
        FirstName = "John",
        LastName = "Doe"
    },
        new Author
        {
            FirstName = "Jonibek",
            LastName = "Doniyorov"
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}


if (appDbContext.Authors.Any() && !appDbContext.Books.Any())
{
    appDbContext.Books.AddRange(new Book
    {
        Title = "Asp.NET Core in Action 2018",
        Description = "Programming",
        AuthorId = appDbContext.Authors.First().Id
    },
        new Book
        {
            Title = "Asp.NET Core in Action 2021",
            Description = "Programming",
            AuthorId = appDbContext.Authors.Skip(1).First().Id
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}