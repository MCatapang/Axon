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

    public override string Address { get; set; }

    public override DateTime Birthday { get; set; }

    public override string EmailAddress { get; set; }

    public List<CareRelation> AssignedEmployees { get; set; } = new List<CareRelation>();
}