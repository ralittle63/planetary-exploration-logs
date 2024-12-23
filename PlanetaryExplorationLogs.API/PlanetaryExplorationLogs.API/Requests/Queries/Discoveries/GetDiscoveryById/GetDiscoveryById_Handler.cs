using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{
    public class GetDiscoveryById_Handler : HandlerBase<Discovery>
    {
        private readonly int _discoveryId;

        public GetDiscoveryById_Handler(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
        {
            _discoveryId = discoveryId;
        }

        public override async Task<RequestResult<Discovery>> HandleAsync()
        {
            var discovery = await DbContext.Discoveries
                .Where(t => t.Id == _discoveryId)
                .SingleOrDefaultAsync();

            var result = new RequestResult<Discovery>
            {
                Data = discovery
            };

            return result;
        }
    }
}
