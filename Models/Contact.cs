#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Contact
{
    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters!")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(20, ErrorMessage = "Must be 20-200 characters long")]
    [MaxLength(200, ErrorMessage = "Must be 20-200 characters long")]
    public string Message { get; set; }
}