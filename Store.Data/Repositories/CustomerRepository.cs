using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class CustomerRepository : EFRepository<Customer>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
