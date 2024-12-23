using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Validator : ValidatorBase
    {
        private readonly DiscoveryFormDto _discovery;

        public UpdateDiscovery_Validator(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
            : base(context)
        {
            _discovery = discovery;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Obviously, this is dummy validation logic. Replace it with your own.
            await Task.CompletedTask;

            if (DbContext.Discoveries.Any(d => d.Id == _discovery.Id))
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
                        "The discovery record doesn't exist.");
            }

            // You can also check things in the database, if needed, such as checking if a record exists
            return await ValidResultAsync();
        }
    }
}
