using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using System.Numerics;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Handler : HandlerBase<int>
    {
        private readonly MissionFormDto _mission;

        public UpdateMission_Handler(PlanetExplorationDbContext context, MissionFormDto mission)
            : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var updatedMission = await DbContext.Missions.FindAsync(_mission.Id);

            if (updatedMission != null)
            {
                updatedMission.Name = _mission.Name;
                updatedMission.PlanetId = _mission.PlanetId;
                updatedMission.Date = _mission.Date;
                updatedMission.Description = _mission.Description;

                await DbContext.SaveChangesAsync();
            }

            // Return the data
            var result = new RequestResult<int>
            {
                Data = updatedMission?.Id ?? -1,
                StatusCode = HttpStatusCode.OK
            };

            return result;
        }
    }
}
