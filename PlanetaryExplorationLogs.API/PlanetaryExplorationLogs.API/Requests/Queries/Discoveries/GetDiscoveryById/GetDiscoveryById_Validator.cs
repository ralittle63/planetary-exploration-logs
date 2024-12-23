using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{

    public class GetDiscoveryById_Validator : ValidatorBase
    {
        private readonly int _discoveryId;

        public GetDiscoveryById_Validator(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
        {
            _discoveryId = discoveryId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (_discoveryId < 1)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Discovery Id must be greater than 0. Value passed: {_discoveryId}.");
            }

            return await ValidResultAsync();
        }
    }
}