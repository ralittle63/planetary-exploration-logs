using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using System.Numerics;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Handler : HandlerBase<int>
    {
        private readonly DiscoveryFormDto _discovery;

        public UpdateDiscovery_Handler(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
            : base(context)
        {
            _discovery = discovery;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var updatedDiscovery = await DbContext.Discoveries.FindAsync(_discovery.Id);

            if (updatedDiscovery != null)
            {
                updatedDiscovery.MissionId = _discovery.MissionId;
                updatedDiscovery.DiscoveryTypeId = _discovery.DiscoveryTypeId;  
                updatedDiscovery.Name = _discovery.Name;
                updatedDiscovery.Description = _discovery.Description;
                updatedDiscovery.Location = _discovery.Location;

                await DbContext.SaveChangesAsync();
            }

            // Return the data
            var result = new RequestResult<int>
            {
                Data = updatedDiscovery?.Id ?? -1,
                StatusCode = HttpStatusCode.OK
            };

            return result;
        }
    }
}
