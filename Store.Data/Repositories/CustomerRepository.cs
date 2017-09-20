using System.Data.Entity;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class CustomerRepository : EFRepository<Customer>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
