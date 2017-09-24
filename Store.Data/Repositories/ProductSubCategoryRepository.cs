using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class ProductSubCategoryRepository : EFRepository<ProductSubCategory>, IProductSubCategoryRepository
    {
        public ProductSubCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
