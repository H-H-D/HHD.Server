using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Categories;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Categories;

namespace HHD.DAL.Repositories.Categories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
