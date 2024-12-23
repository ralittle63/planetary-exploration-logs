using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById;
using PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{
    public class GetPlanetById_Query : RequestBase<Planet>
    {
        private readonly int _planetId;

        public GetPlanetById_Query(PlanetExplorationDbContext context, int planetId)
        : base(context)
        {
            _planetId = planetId;
        }

        public override IValidator Validator => new GetPlanetById_Validator(DbContext, _planetId);

        public override IHandler<Planet> Handler => new GetPlanetById_Handler(DbContext, _planetId);
    }
}
