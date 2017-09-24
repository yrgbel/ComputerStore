using System;
using System.Threading.Tasks;
using Store.Data.Contracts;
using Store.Data.Helpers;
using Store.Model.POCO_Entities;

namespace Store.Data
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Customers"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class StoreUow : IStoreUow, IDisposable
    {
        public StoreUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        // Code Camper repositories

        //public IRepository<Room> Rooms { get { return GetStandardRepo<Room>(); } }
        public IRepository<OrderDetail> OrderDetails => GetStandardRepo<OrderDetail>();
        public IRepository<OrderProduct> OrderProducts => GetStandardRepo<OrderProduct>();
        public IRepository<ProductBrand> ProductBrands => GetStandardRepo<ProductBrand>();
        public IRepository<ProductCategory> ProductCategories => GetStandardRepo<ProductCategory>();
        public IRepository<ProductManufacturer> ProductManufacturers => GetStandardRepo<ProductManufacturer>();
        public IRepository<Product> Products => GetStandardRepo<Product>();
        public IRepository<ProductSubCategory> ProductSubCategories => GetStandardRepo<ProductSubCategory>();
        public IRepository<CustomerPhone> CustomerPhones => GetStandardRepo<CustomerPhone>();
        public IRepository<Customer> Customers => GetStandardRepo<Customer>();

        //public IRepository<TimeSlot> TimeSlots { get { return GetStandardRepo<TimeSlot>(); } }
        //public IRepository<Track> Tracks { get { return GetStandardRepo<Track>(); } }
        //public ISessionsRepository Sessions { get { return GetRepo<ISessionsRepository>(); } }
        //public IPersonsRepository Persons { get { return GetRepo<IPersonsRepository>(); } }
        //public IAttendanceRepository Attendance { get { return GetRepo<IAttendanceRepository>(); } }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Save pending changes async to the database
        /// </summary>
        public Task CommitAsync()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return DbContext.SaveChangesAsync();
        }

        protected void CreateDbContext()
        {
            DbContext = new StoreDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private StoreDbContext DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext?.Dispose();
            }
        }

        #endregion
    }
}
