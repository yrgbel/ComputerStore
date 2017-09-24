using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class ProductManufacturerRepository : EFRepository<ProductManufacturer>, IProductManufacturerRepository
    {
        public ProductManufacturerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
