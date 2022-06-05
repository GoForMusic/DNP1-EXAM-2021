using System.ComponentModel.DataAnnotations;

namespace Models;

public class Team
{
    [Key]
    public string TeamName { get; set; }
    [Required,MaxLength(50)]
    public string NameOfCoach { get; set; }
    public int Ranking { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
}