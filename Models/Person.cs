#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Person
{
    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [Display( Name = "Home Address")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    public string Facility { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}