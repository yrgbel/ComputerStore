using System.Data.Entity;
using Store.Data.Contracts.Repositories;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
