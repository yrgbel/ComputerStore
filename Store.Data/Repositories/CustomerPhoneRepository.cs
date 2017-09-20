using System.Data.Entity;
using Store.Model.POCO_Entities;
using Store.Model.POCO_Entities;

namespace Store.Data.Repositories
{
    public class CustomerPhoneRepository : EFRepository<CustomerPhone>
    {
        public CustomerPhoneRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
