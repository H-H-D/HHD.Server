using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Commons;
using HHD.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace HHD.DAL.Repositories.Common;


public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly HHDDbContext _dbContext;

    public Repository(HHDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    public async ValueTask<TEntity?> SelectByIdAsync(
        Guid id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken);
    }

    public async ValueTask<TEntity> InsertAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        entity.Id = Guid.Empty;

        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        _dbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async ValueTask<TEntity> DeleteAsync(
        Guid id,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
                     throw new InvalidOperationException();

        entity.DeletedAt = DateTime.UtcNow;

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
