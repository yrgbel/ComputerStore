using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class CartItemRepository : EFRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
