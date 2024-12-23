using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Validator : ValidatorBase
    {
        private readonly int _missionId;

        public GetMissionById_Validator(PlanetExplorationDbContext context, int missionId)
        : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (_missionId < 1)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission Id must be greater than 0. Value passed: {_missionId}.");
            }

            return await ValidResultAsync();
        }
    }
}
