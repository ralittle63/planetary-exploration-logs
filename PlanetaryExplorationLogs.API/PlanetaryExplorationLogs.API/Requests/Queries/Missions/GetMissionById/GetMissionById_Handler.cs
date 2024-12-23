using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Handler : HandlerBase<Mission>
    {
        private readonly int _missionId;

        public GetMissionById_Handler(PlanetExplorationDbContext context, int missionId)
        : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<Mission>> HandleAsync()
        {
            var mission = await DbContext.Missions
                .Where(m => m.Id == _missionId)
                .SingleOrDefaultAsync();

            var result = new RequestResult<Mission>
            {
                Data = mission
            };

            return result;
        }
    }
}
