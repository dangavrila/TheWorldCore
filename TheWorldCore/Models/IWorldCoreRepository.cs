using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldCore.Models
{
    public interface IWorldCoreRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}
