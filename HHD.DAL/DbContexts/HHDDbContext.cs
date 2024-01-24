using HHD.Domain.Entities.Categories;
using HHD.Domain.Entities.Users;
using HHD.Domain.Entities.Users.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HHD.DAL.DbContexts;

public class HHDDbContext : DbContext
{
    public HHDDbContext(DbContextOptions<HHDDbContext> options)
                : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<Category> ProductCategories { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserCredentials> UserCredentials { get; set; }
    public DbSet<VerificationCode> VerificationCodes { get; set; }
    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes { get; set; }
}
