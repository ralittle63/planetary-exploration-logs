using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.AddDiscovery;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMissionDiscovery
{
    public class AddMissionDiscovery_Command : RequestBase<int>
    {
        private readonly int _missionid;
        private readonly DiscoveryFormDto _discovery;

        public AddMissionDiscovery_Command(PlanetExplorationDbContext context, int missionId, DiscoveryFormDto discovery)
            : base(context)
        {
            _missionid = missionId;
            _discovery = discovery;
        }

        public override IValidator Validator =>
            new AddMissionDiscovery_Validator(DbContext, _missionid, _discovery);

        public override IHandler<int> Handler =>
            new AddMissionDiscovery_Handler(DbContext, _missionid, _discovery);
    }
}
