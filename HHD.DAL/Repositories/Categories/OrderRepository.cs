using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Categories;
using HHD.DAL.Repositories.Common;
using HHD.Domain.Entities.Categories;

namespace HHD.DAL.Repositories.Categories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
