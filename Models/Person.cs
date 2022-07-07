#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Person
{
    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
    [Display(Name = "Home Address")]
    public virtual string Address { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [DataType(DataType.Date)]
    public virtual DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    public string Facility { get; set; }

    [Required(ErrorMessage = "Field can't be empty!")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public virtual string EmailAddress { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}