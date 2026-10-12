using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialHX.Models;

public class Student
{
    public int StudentID { get; set; }
    [Required]
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Year { get; set; }
    [Required]
    public required string Email { get; set; }
}
