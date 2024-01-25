using HHD.Domain.Entities.Categories;
using HHD.Domain.Entities.Users;
using HHD.Domain.Entities.Users.Auth;
using Microsoft.EntityFrameworkCore;

namespace HHD.DAL.DbContexts;

public class HHDDbContext : DbContext
{
    public HHDDbContext(DbContextOptions<HHDDbContext> options)
                : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<Category> ProductCategories { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserCredentials> UserCredentials { get; set; }
    public DbSet<VerificationCode> VerificationCodes { get; set; }
    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Users
        //modelBuilder.Entity<User>().HasData(
        //    new User { Id = Guid.Parse("548bfaa7-6905-472f-9f6f-cb9377ed6933"), FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", PhoneNumber = "1234567890" },
        //    new User { Id = Guid.Parse("bd101868-4b7b-4349-b09c-8cedbb5bafac"), FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", PhoneNumber = "9876543210" }
        //    // Add more users as needed
        //);
    }
}
