using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class OrderDetailRepository : EFRepository<OrderDetail>
    {
        public OrderDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
