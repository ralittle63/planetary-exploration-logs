using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMissionDiscovery
{
    public class AddMissionDiscovery_Validator : ValidatorBase
    {
        private readonly int _missionId;
        private readonly DiscoveryFormDto _discovery;

        public AddMissionDiscovery_Validator(PlanetExplorationDbContext context, int missionId, DiscoveryFormDto discovery)
            : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Obviously, this is dummy validation logic. Replace it with your own.
            await Task.CompletedTask;

            if (DbContext.Missions.Any(m => m.Id == _missionId))
            {
                if (string.IsNullOrEmpty(_discovery.Name.Trim()))
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The discovery must have a name.");
                }

                if (string.IsNullOrEmpty(_discovery.Description.Trim()))
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The discovery must have a description.");
                }

                if (string.IsNullOrEmpty(_discovery.Location.Trim()))
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The discovery must have a location.");
                }
            }
            else
            {
                return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The mission record doesn't exist.");
            }

            // You can also check things in the database, if needed, such as checking if a record exists
            return await ValidResultAsync();
        }
    }
}
