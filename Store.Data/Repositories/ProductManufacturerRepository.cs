using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class ProductManufacturerRepository : EFRepository<ProductManufacturer>
    {
        public ProductManufacturerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
