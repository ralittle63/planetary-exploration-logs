using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanets
{
    public class GetPlanets_Validator : ValidatorBase
    {
        public GetPlanets_Validator(PlanetExplorationDbContext context)
            : base(context)
        {
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (!DbContext.Planets.Any())
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "There are no planet records. Please add a planet.");
            }

            return await ValidResultAsync();
        }
    }
}
