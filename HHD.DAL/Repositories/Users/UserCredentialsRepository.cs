using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Commons;
using HHD.DAL.IRepositories.Users;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Users;

namespace HHD.DAL.Repositories.Users;

public class UserCredentialsRepository : Repository<UserCredentials>, IUserCredentialsRepository
{
    public UserCredentialsRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
