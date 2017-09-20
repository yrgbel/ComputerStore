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

        // Repositories
        IRepository<CustomerPhone> CustomerPhone { get; }
        IRepository<Customer> Rooms { get; }
        IRepository<OrderDetail> OrderDetail { get; }
        IRepository<OrderProduct> OrderProduct { get; }
        IRepository<ProductBrand> ProductBrand { get; }
        IRepository<ProductCategory> ProductCategory { get; }
        IRepository<ProductManufacturer> ProductManufacturer { get; }
        IRepository<Product> Product { get; }
        IRepository<ProductSubCategory> ProductSubCategory { get; }
        //ISessionsRepository Sessions { get; }
        //IRepository<TimeSlot> TimeSlots { get; }
        //IRepository<Track> Tracks { get; }
        //IAttendanceRepository Attendance { get; }
    }
}
