#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Facility
{
    [Key]
    public string FacilityID { get; set; }
    
    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(8, ErrorMessage = "Must be at least 8 characters!")]
    public string FacilityName { get; set; }

    // Future: implement One-to-one(Employee to Facility) relationship
}