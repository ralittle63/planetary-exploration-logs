using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Command : RequestBase<int>
    {
        private readonly MissionFormDto _mission;

        public UpdateMission_Command(PlanetExplorationDbContext context, MissionFormDto mission)
            : base(context)
        {
            _mission = mission;
        }

        public override IValidator Validator =>
            new UpdateMission_Validator(DbContext, _mission);

        public override IHandler<int> Handler =>
            new UpdateMission_Handler(DbContext, _mission);
    }
}
