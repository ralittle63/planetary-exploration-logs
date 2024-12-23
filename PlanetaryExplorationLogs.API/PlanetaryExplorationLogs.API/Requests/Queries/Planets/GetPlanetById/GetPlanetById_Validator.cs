using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{
    public class GetPlanetById_Validator : ValidatorBase
    {
        private readonly int _planetId;

        public GetPlanetById_Validator(PlanetExplorationDbContext context, int planetId)
            : base(context)
        {
            _planetId = planetId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (_planetId < 1)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Planet Id must be greater than 0. Value passed: {_planetId}.");
            }

            return await ValidResultAsync();
        }
    }
}
