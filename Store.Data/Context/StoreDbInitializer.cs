using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Context
{
    public class StoreDbInitializer : IDatabaseInitializer<StoreDbContext>
    {
        public void InitializeDatabase(StoreDbContext context)
        {
            if (context.Database.Exists())
            {
                //:ToDo
            }
        }
    }
}
