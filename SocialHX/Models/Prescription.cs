using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace SocialHX.Models;

public enum Status
{
    Active, Complete, Archived
}


public class Prescription
{
    public int PrescriptionID { get; set; }
    [Required]
    public int AppointmentID { get; set; }
    [ForeignKey(nameof(AppointmentID))]
    public Appointment? Appointment { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public int Event1ID { get; set; }
    [ForeignKey(nameof(Event1ID))]
    public Activity? Event1 { get; set; }

    [Required]
    public required string Event1Notes { get; set; }
    [Required]
    public required string Event1OtherPerson { get; set; }

    [Required]
    public int Event2ID { get; set; }
    [ForeignKey(nameof(Event2ID))]
    public Activity? Event2 { get; set; }

    [Required]
    public required string Event2Notes { get; set; }
    [Required]
    public required string Event2OtherPerson { get; set; }

    [Required]
    public int Event3ID { get; set; }
    [ForeignKey(nameof(Event3ID))]
    public Activity? Event3 { get; set; }
    [Required]
    public required string Event3Notes { get; set; }
    [Required]
    public required string Event3OtherPerson { get; set; }

    [Required]
    public int Event4ID { get; set; }
    [ForeignKey(nameof(Event4ID))]
    public Activity? Event4 { get; set; }

    [Required]
    public required string Event4Notes { get; set; }
    [Required]
    public required string Event4OtherPerson { get; set; }
    public DateTime Week1DateTime { get; set; }
    public DateTime Week4DateTime { get; set; }
    // follow-ups happen 1 and 4 weeks after the prescription date.
    // on create and edit so the dates are never typed by hand.
    public void SetFollowUpDates()
    {
        DateTime = DateAndTime.Now;
        Week1DateTime = DateTime.AddDays(7);
        Week4DateTime = DateTime.AddDays(28);
    }
    [Required]
    public required string PrescriptionNotes { get; set; }

    public Status Status { get; set; }
}