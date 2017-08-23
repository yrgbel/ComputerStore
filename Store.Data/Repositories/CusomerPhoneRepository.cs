using System.Data.Entity;

namespace Store.Data.Repositories
{
    public class CusomerPhoneRepository : EFRepository<CusomerPhone>
    {
        public CusomerPhoneRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
