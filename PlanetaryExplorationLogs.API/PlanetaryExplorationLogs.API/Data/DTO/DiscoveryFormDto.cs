﻿using PlanetaryExplorationLogs.API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanetaryExplorationLogs.API.Data.DTO
{
    public class DiscoveryFormDto
    {
        public int? Id { get; set; }

        [Required]
        public int MissionId { get; set; }

        [Required]
        public int DiscoveryTypeId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";

        [StringLength(500)]
        public string Description { get; set; } = "";

        [StringLength(200)]
        public string Location { get; set; } = "";

        public Mission? Mission { get; set; } = null!;

        public DiscoveryType? DiscoveryType { get; set; } = null!;
    }
}