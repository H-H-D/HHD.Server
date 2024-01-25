using Bogus;
using HHD.DAL.DbContexts;
using HHD.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HHD.DAL.SeedData;

public static class EntityFaker 
{
    public static Faker<User> GenerateUserFaker()
    {
        return new Faker<User>()
            .RuleFor(user => user.Id, Guid.NewGuid)
            .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
            .RuleFor(user => user.LastName, faker => faker.Person.LastName)
            .RuleFor(user => user.EmailAddress, faker => faker.Person.Email)
            .RuleFor(user => user.PhoneNumber, faker => faker.Person.Phone);
    }
}
