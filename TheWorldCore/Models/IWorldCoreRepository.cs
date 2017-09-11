using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorldCore.Models
{
    public interface IWorldCoreRepository
    {
        IEnumerable<Trip> GetAllTrips();

        Trip GetTripByName(string tripName);

        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop);

        Task<bool> SaveChangesAsync();

    }
}
