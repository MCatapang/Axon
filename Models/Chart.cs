#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Chart
{
    [Key]
    public int ChartID { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(20, ErrorMessage = "Must be at least 20 characters")]
    public string Content { get; set; }

    public DateTime TimeStamp { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Field can't be empty!")]
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    public int PatientID { get; set; }

    public Employee? Employee { get; set; }

    public Patient? Patient { get; set; }
}