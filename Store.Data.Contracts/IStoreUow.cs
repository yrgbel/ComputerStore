using System.Threading.Tasks;
using Store.Model.POCO_Entities;

namespace Store.Data.Contracts
{
    /// <summary>
    /// Interface for the Store "Unit of Work"
    /// </summary>
    public interface IStoreUow
    {
        // Save pending changes to the data store.
        void Commit();
        Task CommitAsync();

        // Repositories
        IRepository<CustomerPhone> CustomerPhones { get; }
        IRepository<Customer> Customers { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        IRepository<OrderProduct> OrderProducts { get; }
        IRepository<ProductBrand> ProductBrands { get; }
        IRepository<ProductCategory> ProductCategories { get; }
        IRepository<ProductManufacturer> ProductManufacturers { get; }
        IRepository<Product> Products { get; }
        IRepository<ProductSubCategory> ProductSubCategories { get; }
        //ISessionsRepository Sessions { get; }
        //IRepository<TimeSlot> TimeSlots { get; }
        //IRepository<Track> Tracks { get; }
        //IAttendanceRepository Attendance { get; }
    }
}
