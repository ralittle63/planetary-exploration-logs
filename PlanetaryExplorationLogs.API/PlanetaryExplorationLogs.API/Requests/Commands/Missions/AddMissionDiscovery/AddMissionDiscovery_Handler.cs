using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMissionDiscovery
{
    public class AddMissionDiscovery_Handler : HandlerBase<int>
    {
        private readonly int _missionId;
        private readonly DiscoveryFormDto _discovery;

        public AddMissionDiscovery_Handler(PlanetExplorationDbContext context, int missionId, DiscoveryFormDto discovery)
            : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var newDiscovery = new Discovery
            {
                MissionId = _discovery.MissionId,
                DiscoveryTypeId = _discovery.DiscoveryTypeId,
                Name = _discovery.Name,
                Description = _discovery.Description,
                Location = _discovery.Location
            };

            await DbContext.Discoveries.AddAsync(newDiscovery);
            await DbContext.SaveChangesAsync();

            var result = new RequestResult<int>
            {
                Data = newDiscovery.Id,
                StatusCode = HttpStatusCode.Created
            };

            return result;
        }
    }
}
