using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //IPersonsRepository Persons { get; }
        //IRepository<Room> Rooms { get; }
        //ISessionsRepository Sessions { get; }
        //IRepository<TimeSlot> TimeSlots { get; }
        //IRepository<Track> Tracks { get; }
        //IAttendanceRepository Attendance { get; }
    }
}
