using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class OrderProductRepository : EFRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
