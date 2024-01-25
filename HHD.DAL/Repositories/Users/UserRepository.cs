using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Users;
using System.Linq.Expressions;

namespace HHD.DAL.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }

    //public ValueTask<User> DeleteAsync(
    //    Guid id, 
    //    bool saveChanges = true, 
    //    CancellationToken cancellationToken = default)
    //=> base.DeleteAsync(id, saveChanges, cancellationToken);

    //public ValueTask<User> InsertAsync(
    //    User entity, 
    //    bool saveChanges = true, 
    //    CancellationToken cancellationToken = default)
    //=> base.InsertAsync(entity, saveChanges, cancellationToken);

    //public IQueryable<User> SelectAll(
    //    Expression<Func<User, bool>>? predicate = null, 
    //    bool asNoTracking = false)
    //=> base.SelectAll(predicate, asNoTracking);

    //public ValueTask<User> SelectByIdAsync(
    //    Guid id, 
    //    bool asNoTracking = false, 
    //    CancellationToken cancellationToken = default)
    //=> base.SelectByIdAsync(id, asNoTracking, cancellationToken);

    //public ValueTask<User> UpdateAsync(
    //    User entity, 
    //    bool saveChanges = true, 
    //    CancellationToken cancellationToken = default)
    //=> base.UpdateAsync(entity, saveChanges, cancellationToken);
}
