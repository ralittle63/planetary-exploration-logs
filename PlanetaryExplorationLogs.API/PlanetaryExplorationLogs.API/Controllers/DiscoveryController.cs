using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.AddDiscovery;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscovery;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Numerics;
using PlanetaryExplorationLogs.API.Requests.Commands.Planets.DeletePlanet;
using PlanetaryExplorationLogs.API.Requests.Commands.Planets;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public DiscoveryController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/discovery/types
        [HttpGet("types")]
        public async Task<ActionResult<RequestResult<List<DiscoveryType>>>> GetDiscoveryTypes()
        {
            var query = new GetDiscoveryTypes_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/discovery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<Discovery>>> GetDiscovery(int id)
        {
            // Retrieve a specific discovery by ID.
            var query = new GetDiscoveryById_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // POST: api/discovery
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateDiscovery([FromBody] DiscoveryFormDto discovery)
        {
            var cmd = new AddDiscovery_Command(_context, discovery);
            return await cmd.ExecuteAsync();
        }

        // PUT: api/discovery/{id}
        [HttpPut]
        public async Task<ActionResult<RequestResult<int>>> UpdateDiscovery([FromBody] DiscoveryFormDto discovery)
        {
            // Update an existing discovery.
            var cmd = new UpdateDiscovery_Command(_context, discovery);
            return await cmd.ExecuteAsync();
        }

        // DELETE: api/discovery/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteDiscovery(int id)
        {
            // Delete a discovery.
            var cmd = new DeleteDiscovery_Command(_context, id);
            return await cmd.ExecuteAsync();
        }
    }
}
