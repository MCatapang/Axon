#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class CareRelation
{
    [Key]
    public int CareRelationID { get; set; }

    [Required]
    public int EmployeeID { get; set; }

    [Required]
    public int PatientID { get; set; }

    public Employee? Employee { get; set; }

    public Patient? Patient { get; set; }
}