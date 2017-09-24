using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class ProductCategoryRepository : EFRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
