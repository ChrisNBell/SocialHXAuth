using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public enum Submitter
{
    Student, Faculty, Staff, OtherStudent
}


public enum Concerns
{
    Yes, No, Unsure
}
public class Referral
{
    public int ReferralID { get; set; }
    [Required]
    public int StudentID { get; set; }
    [ForeignKey(nameof(StudentID))]
    public Student? Student { get; set; }
    public required Submitter Submitter { get; set; }
    [Required]
    public required string SubmitterFirstName { get; set; }
    [Required]
    public required string SubmitterLastName { get; set; }
    [Required]
    public required string SubmitterEmail { get; set; }
    [Required]
    public required bool StudentAware { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required Concerns Concerns { get; set; }
}