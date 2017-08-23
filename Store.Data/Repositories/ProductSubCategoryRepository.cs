using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class ProductSubCategoryRepository : EFRepository<ProductSubCategory>
    {
        public ProductSubCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
