using PlanetaryExplorationLogs.API.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanetaryExplorationLogs.API.Data.DTO
{
    public class MissionFormDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PlanetId { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = "";

        public Planet? Planet { get; set; } = null!;

        public List<Discovery> Discoveries { get; set; } = [];
    }
}
