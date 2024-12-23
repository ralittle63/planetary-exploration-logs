using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Handler : HandlerBase<List<Discovery>>
    {
        private readonly int _missionId;

        public GetDiscoveriesForMission_Handler(PlanetExplorationDbContext context, int missionId)
        : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<List<Discovery>>> HandleAsync()
        {
            var discoveries = await DbContext.Discoveries
                .Include(d => d.DiscoveryType)
                .Include(d => d.Mission)
                .Where(d => d.MissionId == _missionId)
                .ToListAsync();

            var result = new RequestResult<List<Discovery>>
            {
                Data = discoveries
            };

            return result;
        }
    }
}
