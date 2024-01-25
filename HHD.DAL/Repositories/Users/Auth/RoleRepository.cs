using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users.Auth;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Users.Auth;

namespace HHD.DAL.Repositories.Users.Auth;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
