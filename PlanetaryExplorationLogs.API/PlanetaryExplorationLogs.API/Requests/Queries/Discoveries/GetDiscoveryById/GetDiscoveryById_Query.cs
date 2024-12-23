using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{
    public class GetDiscoveryById_Query : RequestBase<Discovery>
    {
        private readonly int _discoveryId;

        public GetDiscoveryById_Query(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
        {
            _discoveryId = discoveryId;
        }

        public override IValidator Validator => new GetDiscoveryById_Validator(DbContext, _discoveryId);

        public override IHandler<Discovery> Handler => new GetDiscoveryById_Handler(DbContext, _discoveryId);
    }
}


