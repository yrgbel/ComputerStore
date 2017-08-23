using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class ProductRepository : EFRepository<Product>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
