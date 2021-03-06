#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class EmployeeLogin
{
    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "Email Address")]
    public string EmailLogin { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string PasswordLogin { get; set; }
}