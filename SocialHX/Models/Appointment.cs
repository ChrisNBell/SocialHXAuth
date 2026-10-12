using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class Appointment
{
    public int AppointmentID { get; set; }
    public int StudentID { get; set; }
    [ForeignKey(nameof(StudentID))]
    public Student? Student { get; set; }
    public int PrescriberID { get; set; }
    [ForeignKey(nameof(PrescriberID))]
    public Prescriber? Prescriber { get; set; }
    [Required]
    public required string Description { get; set; }
}