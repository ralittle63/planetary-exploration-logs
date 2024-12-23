using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Command : RequestBase<int>
    {
        private readonly DiscoveryFormDto _discovery;

        public UpdateDiscovery_Command(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
            : base(context)
        {
            _discovery = discovery;
        }

        public override IValidator Validator =>
            new UpdateDiscovery_Validator(DbContext, _discovery);

        public override IHandler<int> Handler =>
            new UpdateDiscovery_Handler(DbContext, _discovery);
    }
}
