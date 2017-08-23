using System.Data.Entity;

namespace Store.Data.Repositories
{
    class ProductCategoryRepository : EFRepository<ProductCategory>
    {
        public ProductCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
