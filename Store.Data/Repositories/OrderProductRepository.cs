using System.Data.Entity;

namespace Store.Data.Repositories
{
    class OrderProductRepository : EFRepository<OrderProduct>
    {
        public OrderProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
