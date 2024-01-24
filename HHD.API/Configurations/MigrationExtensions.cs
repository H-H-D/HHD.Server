//using HHD.API.Configurations;
//using Microsoft.EntityFrameworkCore;
//using HHD.DAL.DbContexts;

//namespace HHD.API.Configurations;

//public static class MigrationExtensions
//{
//    public static async ValueTask MigrateAsync(this IServiceScopeFactory scopeFactory) 
//    {
//        await using var scope = scopeFactory.CreateAsyncScope();
//        var context = scope.ServiceProvider.GetRequiredService<HHDDbContext>();

//        if ((await context.Database.getpen).Any())
//            await context.Database.MigrateAsync();
//    }
//}