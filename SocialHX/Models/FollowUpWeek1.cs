using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class FollowUpWeek1
{
    public int FollowUpWeek1ID { get; set; }
    [Required]
    public int PrescriptionID { get; set; }
    [ForeignKey(nameof(PrescriptionID))]
    public Prescription? Prescription { get; set; }
    public Boolean Response { get; set; }
    [Required]
    public required string StudentReport { get; set; }
    [Required]
    public required string StudentAdjustments { get; set; }

}