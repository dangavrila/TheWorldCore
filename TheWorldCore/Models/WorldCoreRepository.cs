using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;


namespace TheWorldCore.Models
{
    public class WorldCoreRepository : IWorldCoreRepository
    {
        private readonly WorldCoreContext _context;
        private readonly ILogger<WorldCoreRepository> _logger;

        public WorldCoreRepository(WorldCoreContext context, ILogger<WorldCoreRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting all trips.");
            return _context.Trips.ToList();
        }
    }
}
