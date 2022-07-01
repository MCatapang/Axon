#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Role
{
    [Key]
    public string RoleID { get; set; }
    
    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
    [MaxLength(25, ErrorMessage = "Must be less than 25 characters")]
    public string RoleName { get; set; }

    // Future: implement One-to-Many(Employee to Role) relationship
}