﻿using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Validator : ValidatorBase
    {
        private readonly MissionFormDto _mission;

        public UpdateMission_Validator(PlanetExplorationDbContext context, MissionFormDto mission)
            : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Obviously, this is dummy validation logic. Replace it with your own.
            await Task.CompletedTask;

            if (DbContext.Missions.Any(m => m.Id == _mission.Id))
            {
                if (string.IsNullOrEmpty(_mission.Name.Trim()))
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The mission must have a name.");
                }

                if (string.IsNullOrEmpty(_mission.Description.Trim()))
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The mission must have a description.");
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