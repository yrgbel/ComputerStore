using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class CartRepository : EFRepository<Cart>, ICartRepository
    {
        public CartRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
