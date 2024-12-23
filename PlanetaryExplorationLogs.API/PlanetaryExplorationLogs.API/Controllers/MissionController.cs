using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.AddDiscovery;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMissionDiscovery;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Reflection;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public MissionController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/mission
        [HttpGet]
        public async Task<ActionResult<RequestResult<List<Mission>>>> GetMissions()
        {
            var query = new GetMissions_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/mission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<Mission>>> GetMissionById(int id)
        {
            // Retrieve a specific mission by ID.
            var query = new GetMissionById_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] MissionFormDto mission)
        {
            // Create a new mission.
            var cmd = new AddMission_Command(_context, mission);
            return await cmd.ExecuteAsync();
        }

        // PUT: api/mission
        [HttpPut]
        public async Task<ActionResult<RequestResult<int>>> UpdateMission([FromBody] MissionFormDto mission)
        {
            // Update an existing mission.
            var cmd = new UpdateMission_Command(_context, mission);
            return await cmd.ExecuteAsync();
        }

        // DELETE: api/mission/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        {
            // Delete a mission by ID.
            var cmd = new DeleteMission_Command(_context, id);
            return await cmd.ExecuteAsync();
        }

        // GET: api/mission/{missionId}/discovery
        [HttpGet("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<List<Discovery>>>> GetDiscoveriesForMission(int missionId)
        {
            // Retrieve all discoveries for a specific mission.
            var query = new GetDiscoveriesForMission_Query(_context, missionId);
            return await query.ExecuteAsync();
        }

        // POST: api/mission/{missionId}/discovery
        [HttpPost("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<int>>> CreateDiscoveryForMission(int missionId, [FromBody] DiscoveryFormDto discovery)
        {
            // Create a new discovery under a specific mission.
            var cmd = new AddMissionDiscovery_Command(_context, missionId, discovery);
            return await cmd.ExecuteAsync();
        }

    }
}
