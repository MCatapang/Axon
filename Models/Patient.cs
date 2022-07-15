#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Patient : Person
{
    [Key]
    public int PatientID { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    public string Complaint { get; set; }

    [Display(Name = "Home Address")]
    public override string? Address { get; set; }

    [DataType(DataType.Date)]
    public override DateTime? Birthday { get; set; }

    [Display(Name = "Email Test")]
    public override string? EmailAddress { get; set; }

    public List<CareRelation> AssignedEmployees { get; set; } = new List<CareRelation>();
}