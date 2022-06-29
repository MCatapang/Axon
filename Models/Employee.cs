#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Employee : Person
{
    [Key]
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "Primary Role")]
    public string PrimaryRole { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(8, ErrorMessage = "Must be at least 8 characters!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = " Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords must match!")]
    [DataType(DataType.Password)]
    public string Confirm { get; set; }

    public List<CareRelation> AssignedPts { get; set; } = new List<CareRelation>();
}