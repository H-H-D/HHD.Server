using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Users;

namespace HHD.DAL.Repositories.Users;

public class UserInfoVerificationCodeRepository : Repository<UserInfoVerificationCode>, IUserInfoVerificationCodeRepository
{
    public UserInfoVerificationCodeRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
