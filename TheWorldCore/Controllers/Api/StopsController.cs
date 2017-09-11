using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorldCore.Models;
using TheWorldCore.Services;
using TheWorldCore.ViewModels;

namespace TheWorldCore.Controllers.Api
{
    [Route("/api/trips/{tripName}/stops")]
    public class StopsController : Controller
    {
        private readonly IWorldCoreRepository _repository;
        private readonly ILogger<StopsController> _logger;
        private readonly GeoCoordService _geoCoordService;

        public StopsController(IWorldCoreRepository repository, ILogger<StopsController> logger, GeoCoordService geoCoordService)
        {
            _repository = repository;
            _logger = logger;
            _geoCoordService = geoCoordService;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripByName(tripName);
                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get stops for trip. Exception: {ex}");
                return BadRequest($"Failed to get stops for trip: {tripName}");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<Stop>(vm);

                    var result = await _geoCoordService.GetCoordAsync(newStop.Name);
                    if (!result.Success)
                    {
                        _logger.LogError(result.Message);
                    }
                    else
                    {
                        newStop.Latitude = result.Latitude;
                        newStop.Longitude = result.Longitude;

                        _repository.AddStop(tripName, newStop);

                        if (await _repository.SaveChangesAsync())
                        {
                            return Created($"/api/trips/{tripName}/{newStop.Name}",
                                Mapper.Map<StopViewModel>(newStop));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new stop: {0}", ex);
            }

            return BadRequest($"Failed to add stop for Trip: {tripName}");
        }
    }
}
