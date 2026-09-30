using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class Activity
{
    public int ActivityID { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    public DateTime DateTime { get; set; }
    [Required]
    public required string Location { get; set; }

}