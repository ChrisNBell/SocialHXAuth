using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public enum Status
{
    Active, Complete, Archived
}


public class Prescription
{
    public int PrescriptionID { get; set; }

    [Required]
    public int StudentID { get; set; }
    [ForeignKey(nameof(StudentID))]
    public Student? Student { get; set; }

    [Required]
    public int PrescriberID { get; set; }
    [ForeignKey(nameof(PrescriberID))]
    public Prescriber? Prescriber { get; set; }

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

    public Status Status { get; set; }
}