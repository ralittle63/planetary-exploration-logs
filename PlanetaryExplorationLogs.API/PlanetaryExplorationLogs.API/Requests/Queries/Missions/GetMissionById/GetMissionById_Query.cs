using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Query : RequestBase<Mission>
    {
        private readonly int _missionId;

        public GetMissionById_Query(PlanetExplorationDbContext context, int missionId)
        : base(context)
        {
            _missionId = missionId;
        }

        public override IValidator Validator => new GetMissionById_Validator(DbContext, _missionId);

        public override IHandler<Mission> Handler => new GetMissionById_Handler(DbContext, _missionId);
    }
}
