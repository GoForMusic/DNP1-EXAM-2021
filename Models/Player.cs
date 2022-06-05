using System.ComponentModel.DataAnnotations;

namespace Models;


public class Player
{
    [Key]
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [Range(1,99)]
    public int ShirtNumber { get; set; }
    public decimal Salary { get; set; }
    public int GoalsThisSeason { get; set; }
    [Required]
    public string Position { get; set; }
}