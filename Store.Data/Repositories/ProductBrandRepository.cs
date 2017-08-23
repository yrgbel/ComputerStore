using System.Data.Entity;

namespace Store.Data.Repositories
{
    class ProductBrandRepository : EFRepository<ProductBrand>
    {
        public ProductBrandRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
