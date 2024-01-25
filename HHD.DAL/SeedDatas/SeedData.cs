using HHD.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace HHD.DAL.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this HHDDbContext dbContext)
    {
        if (!dbContext.Users.Any())
            await dbContext.AddUsers(10);

    }

    public static async ValueTask<int> AddUsers(this HHDDbContext dbContext, int count)
    {
        var faker = EntityFaker.GenerateUserFaker();
        var users = faker.Generate(count);
        await dbContext.Users.AddRangeAsync(users);

        return await dbContext.SaveChangesAsync();
    }

}