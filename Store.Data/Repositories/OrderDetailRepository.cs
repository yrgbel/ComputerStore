using System.Data.Entity;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class OrderDetailRepository : EFRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
