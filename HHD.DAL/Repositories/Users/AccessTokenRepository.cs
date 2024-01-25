using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Users;

namespace HHD.DAL.Repositories.Users;

public class AccessTokenRepository : Repository<AccessToken>, IAccessTokenRepository
{
    public AccessTokenRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
