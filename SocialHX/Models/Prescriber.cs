using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class Prescriber
{
    [Key]
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Department { get; set; }
    [Required]
    public required string Location { get; set; }
}