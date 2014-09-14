using System.ComponentModel.DataAnnotations;

namespace TeamsAndEmployees.Models
{
    public abstract class TeamBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}