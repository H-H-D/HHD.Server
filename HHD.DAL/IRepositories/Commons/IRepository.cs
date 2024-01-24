using HHD.Domain.Entities.Commons;
using System.Security.AccessControl;

namespace HHD.DAL.IRepositories.Commons;

public interface IRepository<TEntity> where TEntity : Auditable
{
    ValueTask<bool> DeleteAsync(Guid id);
    IQueryable<TEntity> SelectAll();
    ValueTask<TEntity> SelectByIdAsync(Guid id);
    ValueTask<TEntity> InsertAsync(TEntity entity);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
}
