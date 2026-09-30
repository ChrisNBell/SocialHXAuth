using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class FollowUpWeek4
{
    public int FollowUpWeek4ID { get; set; }
    [Required]
    public int PrescriptionID { get; set; }
    [ForeignKey(nameof(PrescriptionID))]
    public Prescription? Prescription { get; set; }
    public Boolean DidMeet { get; set; }
    public DateTime DateTime { get; set; }
    public Boolean DidAttend { get; set; }

    public int EventsAttended { get; set; }
    [Required]
    public required string Feelings { get; set; }
    [Required]
    public required string Barriers { get; set; }
    public Boolean Refill { get; set; }

}