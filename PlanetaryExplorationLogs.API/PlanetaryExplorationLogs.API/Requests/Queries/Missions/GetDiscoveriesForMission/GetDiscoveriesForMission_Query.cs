using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Query : RequestBase<List<Discovery>>
    {
        private readonly int _missionId;

        public GetDiscoveriesForMission_Query(PlanetExplorationDbContext context, int missionId)
        : base(context)
        {
            _missionId = missionId;
        }

        public override IValidator Validator => new GetDiscoveriesForMission_Validator(DbContext, _missionId);

        public override IHandler<List<Discovery>> Handler => new GetDiscoveriesForMission_Handler(DbContext, _missionId);
    }
}
