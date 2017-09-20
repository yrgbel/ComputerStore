using System.Data.Entity;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    class ProductBrandRepository : EFRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
