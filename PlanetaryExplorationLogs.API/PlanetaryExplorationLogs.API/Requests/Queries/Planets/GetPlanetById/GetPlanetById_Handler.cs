using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{
    public class GetPlanetById_Handler : HandlerBase<Planet>
    {
        private readonly int _planetId;

        public GetPlanetById_Handler(PlanetExplorationDbContext context, int planetId)
        : base(context)
        {
            _planetId = planetId;
        }

        public override async Task<RequestResult<Planet>> HandleAsync()
        {
            var planet = await DbContext.Planets
                .Where(p => p.Id == _planetId)
                .SingleOrDefaultAsync();

            var result = new RequestResult<Planet>
            {
                Data = planet
            };

            return result;
        }
    }
}
